    DataTable table = CreateTable(rows);
    using (var bulkCopy = new SqlBulkCopy(connectionString))
    {
        foreach (var col in table.Columns.OfType<DataColumn>())
        {
            bulkCopy.ColumnMappings.Add(
                new SqlBulkCopyColumnMapping(col.ColumnName, col.ColumnName));
        }
        bulkCopy.BulkCopyTimeout = 600; // in seconds
        bulkCopy.DestinationTableName = "<tableName>";
        bulkCopy.WriteToServer(table);
    }
