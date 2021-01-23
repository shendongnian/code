    static DataTable ConvertListToDataTable(List<List<string>> list, IList<string> columnNames)
    {
        DataTable table = new DataTable();
        foreach(string columnName in columnNames)
            table.Columns.Add(columnName);
        foreach(List<string> row in list){
            table.Rows.Add(row.ToArray());
        }
        return table;
    }
