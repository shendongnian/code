    table.Columns.Cast<DataColumn>()
        .Where(column => column.DataType == typeof(string))
        .Select(column => new 
        { 
            column.ColumnName, 
            MaxLength = table.Rows.Cast<DataRow>()
                .Where(row => !row.IsNull(column))
                .Select(row => ((string)row[column]).Length)
                .Max() 
        });
