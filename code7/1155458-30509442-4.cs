    var columns =
        from DataRow row in table.Rows
        from DataColumn column in table.Columns
        where column.DataType == typeof(string) && !row.IsNull(column)
        let length = ((string)row[column]).Length
        group length by column.ColumnName into g
        select new
        {
            ColumnName = g.Key,
            MaxLength = g.Max()
        };
