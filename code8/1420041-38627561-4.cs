    List<T> SelectDistict(DataTable table, string column)
    {
        DataTable temp = new DataView(table).ToTable(true, column);
        List<T> items = new List<T>();
        foreach (DataRow row in temp.Rows)
            items.Add(row.Field<T>(column));
        return items;
    }
