    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
    {
        bulkCopy.ColumnMappings.Add("Name", "Name"); //NEW
        bulkCopy.ColumnMappings.Add("BulkInsertID", "BulkInsertID"); //NEW
        bulkCopy.DestinationTableName = table.TableName;
        bulkCopy.WriteToServer(table);
    }
