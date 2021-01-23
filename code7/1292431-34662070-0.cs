    sourceConn_transDB.Open();
    using(SqlCommand sourceCommand = new SqlCommand(queryString, sourceConn_transDB))
    {
        sourceCommand.CommandTimeout = 600;
    
        using (SqlDataReader reader = sourceCommand.ExecuteReader())
        using (SqlBulkCopy bulk = new SqlBulkCopy(targetConn_reportDB, SqlBulkCopyOptions.KeepIdentity, null) { DestinationTableName = "PatientEvent" })
        {
            bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("PatientID", "PatientID"));
            bulk.WriteToServer(reader);
        }
    }
