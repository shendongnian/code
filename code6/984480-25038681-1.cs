    var table_list = new DataTable();
    table_list.Columns.Add();
    foreach(string[] fields in lists)
    {
        DataRow newRow = table_list.Rows.Add();
        newRow.SetField(0, string.Join("", fields));
    }
