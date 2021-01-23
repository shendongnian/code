    static DataTable ConvertListToDataTable(List<List<string>> list, IList<string> columnNames)
    {
        DataTable table = new DataTable();
        foreach (string columnName in columnNames)
            table.Columns.Add(columnName);
        foreach (List<string> row in list)
        {
            if (row.Count != columnNames.Count)
                throw new ArgumentException(string.Format("Invalid data in list, must have the same columns as the columnNames-argument. Line was: '{0}'", string.Join(",", row)), "list");
            DataRow r =  table.Rows.Add();
            for (int i = 0; i < columnNames.Count; i++)
                r[i] = row[i];
        }
        return table;
    }
