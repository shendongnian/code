    var columns = table.Rows.Cast<DataRow>()
        .SelectMany(row => table.Columns.Cast<DataColumn>(), (row, column) => new { row, column })
        .Where(pair => pair.column.DataType == typeof(string) && !pair.row.IsNull(pair.column))
        .GroupBy(pair => pair.column.ColumnName, (key, items) => new 
        { 
            ColumnName = key, 
            MaxLength = items.Max(x => ((string)x.row[x.column]).Length) 
        });
