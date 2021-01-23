    DataColumn[] replaceColumns = table.Columns.Cast<DataColumn>()
        .Where(c => new[] { "Column1", "Column2" }.Contains(c.ColumnName))
        .ToArray();
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in replaceColumns)
        { 
            string newStr = userRegex.Replace(row.Field<string>(col), "$1");
            row.SetField(col, newStr);
        }
    }
