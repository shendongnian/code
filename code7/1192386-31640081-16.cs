    var rhDs = new DataSet();
    rhDs.ReadXml("dat.xml");
    foreach (DataTable table in rhDs.Tables)
    {
        Console.WriteLine("Table: {0}\r\n", table.TableName);
        foreach (DataColumn column in table.Columns)
        {
            Console.Write("{0}\t", column.ColumnName);
        }
        Console.WriteLine("\r\n-----------------------------------------");
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("{0}\t", row[column]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
