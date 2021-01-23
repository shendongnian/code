        var dateColumns = dt.Columns.Cast<DataColumn>().Where(x => x.DataType == typeof(DateTime));
        foreach (DataColumn column in dateColumns)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[column.ColumnName] = DateTime.Parse("1/1/4");
            }
        }
