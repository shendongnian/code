    Console.WriteLine("My table has: " + dt.Columns.Count + " columns.");  //just for testing
    List<string> columnNames = new List<string>();
    foreach (DataColumn column in dt.Columns)
    {
    	columnNames.Add(column.ColumnName);
    }
