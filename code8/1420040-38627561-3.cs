    List<string> SelectDistict(DataTable t, string columnName)
    {
        DataTable table = t.Copy();
        string column = string.Format("{0}_Copy", columnName);
        table.Columns.Add(column, typeof(string), string.Format("TRIM({0})", columnName));
        DataTable temp = new DataView(table.Copy()).ToTable(true, column);
        List<string> items = new List<string>();
        foreach (DataRow row in temp.Rows)
        {
            items.Add(row.Field<string>(column));
        }
        return items;
    }
