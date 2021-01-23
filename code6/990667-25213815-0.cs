    private void PrintTable(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            PrintRow(table, row);
        }
    }
    private void PrintRow(DataTable table, DataRow row)
    {
        foreach(DataColumn column in table.Columns)
        {
            Console.Write(row[column]) + " ";
        }
    }
