    public DataTable CreateDataTable(List<List<decimal>> data)
    {
        DataTable table = new DataTable();
        if (data.Count == 0)
            return table;
        int fields = data[0].Count;
        for (int i = 0; i < fields; i++)
        {
            table.Columns.Add("column" + (i + 1), typeof (decimal));
        }
        foreach (var list in data)
        {
            var row = table.NewRow();
            for (int i = 0; i < fields; i++)
            {
                row.SetField(i, list[i]);
            }
            table.Rows.Add(row);
        }
        return table;
    }
