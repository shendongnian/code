    foreach (DataColumn col in table.Columns)
           Console.Write(string.Format("{0,10}", col.ColumnName) + " ");
    Console.WriteLine();
    foreach (DataRow row in table.Rows)
    {
       foreach (DataColumn col in table.Columns)
            Console.Write(string.Format("{0,10}", row[col.ColumnName]) + " ");
       Console.WriteLine();
    }
