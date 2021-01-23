        DataSet ds = new DataSet();
        ds.Tables.Add(new DataTable("myTable"));
        da.FillSchema(ds.Tables["mytable"], SchemaType.Source);
        var dataTableName = "someDataSet";
        var TownDataSet = new DataSet("newDataSet");
        var checkDataSet = new DataSet();
        /* add a new DataTable to the DataSet.Tables collection */
        checkDataSet.Tables.Add(new DataTable(dataTableName));
        /*
         * Fit the sql statement and the connection string depending on your scenario
         * Set the *Command, *Connection and *DataAdapter actual provider
         */
        SqlCommand cmd = new SqlCommand("select * from myTable");
        SqlConnection conn = new SqlConnection("my connection string");
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = conn;
        da.SelectCommand = cmd;
        /* that's it: the datatable is now mapped with the corresponding db table structure */
        da.FillSchema(checkDataSet.Tables[dataTableName], SchemaType.Source);
