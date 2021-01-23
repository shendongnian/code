       var dataTableName = "someDataSet";
       var TownDataSet = new DataSet("newDataSet");
       var checkDataSet = new DataSet();
       /* add a new DataTable to the DataSet.Tables collection */
       checkDataSet.Tables.Add(new DataTable(dataTableName));
 
       /* add a new DataRow the the Tables[dataTableName].Rows collection */
       var r = TownDataSet.Tables[dataTableName].NewRow();
       TownDataSet.Tables[dataTableName].Rows.Add(r);
