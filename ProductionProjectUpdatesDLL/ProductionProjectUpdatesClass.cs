/* Title:           Production Project Updates Class
 * Date:            1-74-20
 * Author:          Terry Holmes
 * 
 * Description:     This is used to process updates*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace ProductionProjectUpdatesDLL
{
    public class ProductionProjectUpdatesClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        ProductionProjectUpdatesDataSet aProductionProjectUpdatesDataset;
        ProductionProjectUpdatesDataSetTableAdapters.productionprojectupdatesTableAdapter aProductionProjectUpdatesTableAdapter;

        InsertProductionProjectUpdateEntryTableAdapters.QueriesTableAdapter aInsertProductionProjectUpdateTableAdapter;

        FindProductionProjectUpdateByProjectIDDataSet aFindProductionProjectUpdateByProjectIDDataSet;
        FindProductionProjectUpdateByProjectIDDataSetTableAdapters.FindProductionProjectUpdatesByProjectIDTableAdapter aFindProductionProjectUpdateByProjectIDTableAdapter;

        public FindProductionProjectUpdateByProjectIDDataSet FindProductionProjectUpdateByProjectID(int intProjectID)
        {
            try
            {
                aFindProductionProjectUpdateByProjectIDDataSet = new FindProductionProjectUpdateByProjectIDDataSet();
                aFindProductionProjectUpdateByProjectIDTableAdapter = new FindProductionProjectUpdateByProjectIDDataSetTableAdapters.FindProductionProjectUpdatesByProjectIDTableAdapter();
                aFindProductionProjectUpdateByProjectIDTableAdapter.Fill(aFindProductionProjectUpdateByProjectIDDataSet.FindProductionProjectUpdatesByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Production Project Update Class // Find Production Project Update By Project ID " + Ex.Message);
            }

            return aFindProductionProjectUpdateByProjectIDDataSet;
        }
        public bool InsertProductionProjectUpdate(int intProjectID, int intEmployeeID, string strProjectUpdate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertProductionProjectUpdateTableAdapter = new InsertProductionProjectUpdateEntryTableAdapters.QueriesTableAdapter();
                aInsertProductionProjectUpdateTableAdapter.InsertProductionProjectUpdate(intProjectID, intEmployeeID, DateTime.Now, strProjectUpdate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Production Project Updates Class // Insert Production Project Update " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ProductionProjectUpdatesDataSet GetProductionProjectsUpdateInfo()
        {
            try
            {
                aProductionProjectUpdatesDataset = new ProductionProjectUpdatesDataSet();
                aProductionProjectUpdatesTableAdapter = new ProductionProjectUpdatesDataSetTableAdapters.productionprojectupdatesTableAdapter();
                aProductionProjectUpdatesTableAdapter.Fill(aProductionProjectUpdatesDataset.productionprojectupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Production Project Updates Class // Get Production Project Updates Info " + Ex.Message);          
            }

            return aProductionProjectUpdatesDataset;
        }
        public void UpdateProductionProjectUpdatesDB(ProductionProjectUpdatesDataSet aProductionProjectUpdatesDataset)
        {
            try
            {
                aProductionProjectUpdatesTableAdapter = new ProductionProjectUpdatesDataSetTableAdapters.productionprojectupdatesTableAdapter();
                aProductionProjectUpdatesTableAdapter.Update(aProductionProjectUpdatesDataset.productionprojectupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Production Project Updates Class // Update Production Project Updates DB " + Ex.Message);
            }
        }

    }
}
