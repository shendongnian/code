    public DataTable ToDataTable(IList<ListItem> data)
    {
        var table = new DataTable();
        table.Columns.Add("Value", typeof(string));
        table.Columns.Add("Text", typeof(string));
        foreach (T item in data)
        {
            var row = table.NewRow();
            row["Value"] = item.Value;
            row["Text"] = item.Text;
            table.Rows.Add(row);
        }
        return table;
    }
