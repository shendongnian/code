    var bulkCopy = new SqlBulkCopy(connection);
    bulkCopy.DestinationTableName = "table2";
    bulkCopy.ColumnMappings.Add("Name", "Name");
 
    using (var reader = new EntityDataReader<Table1>(query))
    {
        bulkCopy.WriteToServer(reader);
    }
