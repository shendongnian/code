    List<T> SelectDistict<T>(DataTable t, string columnName)
    {
        DataTable table = t.Copy();
        string column = string.Format("{0}_Copy", columnName);
        table.Columns.Add(column, typeof(T), string.Format("TRIM({0})", columnName));
        DataTable temp = new DataView(table.Copy()).ToTable(true, column);
        List<T> items = new List<T>();
        foreach (DataRow row in temp.Rows)
        {
            items.Add(row.Field<T>(column));
        }
        return items;
    }
