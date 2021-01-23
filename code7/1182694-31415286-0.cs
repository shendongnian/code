    using (SqlConnection destinationConnection = new    SqlConnection(connectionString))
    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
    {
        bulkCopy.DestinationTableName = "External_File";
        bulkCopy.WriteToServer(dataTable);
    }
