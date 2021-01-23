    // define a DataTable with the columns of your target table
    DataTable tblToInsert = new DataTable();
    tblToInsert.Columns.Add(new DataColumn("SomeValue", typeof (int)));
    // insert your data into that DataTable
    for (int index = 0; index < 60000; index++)
    {
        DataRow row = tblToInsert.NewRow();
        row["SomeValue"] = index;
        tblToInsert.Rows.Add(row);
    }
        
    // set up your SQL connection     
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    {
        // define your SqlBulkCopy
        SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
        // give it the name of the destination table WHICH MUST EXIST!
        bulkCopy.DestinationTableName = "BulkTestTable";
        // measure time needed
        Stopwatch sw = new Stopwatch();
        sw.Start();
        // open connection, bulk insert, close connection
        connection.Open();
        bulkCopy.WriteToServer(tblToInsert);
        connection.Close();
        // stop time measurement
        sw.Stop();
        long milliseconds = sw.ElapsedMilliseconds;
    }
