       var dataTableName = "someDataSet";
       var TownDataSet = new DataSet("newDataSet");
       var checkDataSet = new DataSet();
       /* add a new DataTable to the DataSet.Tables collection */
       checkDataSet.Tables.Add(new DataTable(dataTableName));
 
        /* maybe you need to add some columns too */
        checkDataSet.Tables[dataTableName].Columns.Add(new DataColumn("columnA", typeof(int)));
        checkDataSet.Tables[dataTableName].Columns.Add(new DataColumn("columnB", typeof(string)));
        /* create and initialize a new DataRow for the Tables[dataTableName] table */
        var r = TownDataSet.Tables[dataTableName].NewRow();
        r["columnA"] = 1;
        r["columnB"] = "Some value";
        /* add it to the Tables[dataTableName].Rows collection */
        TownDataSet.Tables[dataTableName].Rows.Add(r);
