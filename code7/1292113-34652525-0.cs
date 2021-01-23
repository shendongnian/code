    foreach (DataRow row in dataTable.Rows)
    {
        foreach(DataColumn column in dataTable.Columns)
        {
            Trace.WriteLine(column.ColumnName + " = " + row[column]);
        }
    }
