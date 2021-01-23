    DataTable table = new DataTable();
    table.Columns.Add("Title");
    table.Columns.Add("11/09/2015"); // string is default
    table.Columns.Add("23/01/2015");
    DataRow firstRow = table.NewRow();
    for (var i = 0; i < table.Columns.Count; i++)
    {
        string colName = table.Columns[i].ColumnName;
        firstRow.SetField(i, colName);
    }
    table.Rows.InsertAt(firstRow, 0);
