    DataTable table = new DataTable("NewTable");
    
    DataColumn column = new DataColumn("ID1", typeof(System.Int32));
    table.Columns.Add(column);
    
    column = new DataColumn("ID2", typeof(System.Int32));
    table.Columns.Add(column);
    
    DataRow row = table.NewRow();
    row.ItemArray = new object[] { 1, 2};
    table.Rows.Add(row);
    
    row = table.NewRow();
    row.ItemArray = new object[] { 2, 3};
    table.Rows.Add(row);
    
    row = table.NewRow();
    row.ItemArray = new object[] { 10, 2};
    table.Rows.Add(row);
    
    row = table.NewRow();
    row.ItemArray = new object[] { 10, 2 };
    table.Rows.Add(row);
    
    row = table.NewRow();
    row.ItemArray = new object[] { 20, 2};
    table.Rows.Add(row);
    
    row = table.NewRow();
    row.ItemArray = new object[] { 20, 3};
    table.Rows.Add(row);
    
    // Mark all rows as "accepted". Not required
    // for this particular example.
    table.AcceptChanges();
    
    DataView view = new DataView(table);
    view.Sort = "ID1";
    
    DataTable newTable = view.ToTable(true, "ID1", "ID2");
    
    Console.WriteLine("New table name: " + newTable.TableName);
    
    
    foreach (DataRow row1 in newTable.Rows)
    {
    	Console.WriteLine();
    	for(int x = 0; x < newTable.Columns.Count; x++)
    	{
    		Console.Write(row1[x].ToString() + " ");
    	}
    }
    
    Console.ReadLine();
