    DataTable dt = GetDataTableFromExcel(excelFile, true);
    using (var copy = new SqlBulkCopy(yourConnectionString) //There are other overloads too
    {
        BulkCopyTimeout = 10000,
        DestinationTableName = dt.TableName,
    })
    {
        foreach (DataColumn column in dt.Columns)
        {
            copy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
        }
        copy.WriteToServer(dt);
    }
