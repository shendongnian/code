	System.Data.DataTable table = new DataTable("ParentTable");
	DataColumn column;
    DataRow row;
	
	column = new DataColumn();
	column.DataType = typeof(string);
	column.ColumnName = "column1";
	table.Columns.Add(column);
	
	column = new DataColumn();
	column.DataType = typeof(string);
	column.ColumnName = "column2";
	table.Columns.Add(column);
	
	row = table.NewRow();
	row["column1"] = "1";
	row["column2"] = "ABC";
	table.Rows.Add(row);
	
	var results = from myRow in table.AsEnumerable()
					select String.Format("column1 = {0}, column2 = {1}", myRow[0], myRow[1]);
					
	foreach (string r in results)
	{
		Console.WriteLine(r);
	}
