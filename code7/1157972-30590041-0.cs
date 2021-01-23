    StringBuilder sb = new StringBuilder(); 
    
    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                      Select(column => column.ColumnName);
    sb.AppendLine(string.Join(",", columnNames));
    var inv = CultureInfo.InvariantCulture;
    foreach (DataRow row in dt.Rows)
    {
        IEnumerable<string> fields = dt.Columns.Cast<DataColumn>()
            .Select(col => col.DataType == typeof(DateTime)
                ? row.Field<DateTime>(col).ToString("yyyy/MM/dd hh:mm", inv) 
                : row.IsNull(col) ? "" : row[col].ToString());
        sb.AppendLine(string.Join(",", fields));
    }
    
    File.WriteAllText("filename.csv", sb.ToString());
