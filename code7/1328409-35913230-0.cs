    /// <summary>Build data and test the underlying method.</summary>
    public void Main()
    {
    	Dictionary<string, Type> columns = new Dictionary<string, Type>();
    	columns.Add("emp_num", typeof(int));
    	columns.Add("salary", typeof(int));
    	columns.Add("ov", typeof(double));
    	
    	DataTable left = new DataTable();
    	foreach(KeyValuePair<string, Type> column in columns)
    	{
    		left.Columns.Add(column.Key, column.Value);
    	}
    	left.Rows.Add(455, 3000, 67.891);
    	left.Rows.Add(677, 5000, 89.112);
    	left.Rows.Add(778, 6000, 12.672);
    	left.Rows.Add(9001, 5500, 12.672);
    	left.Rows.Add(4, null, 9.2);
    
    	DataTable right = new DataTable();
    	right.Columns.Add("outlier", typeof(string));
    	foreach (KeyValuePair<string, Type> column in columns)
    	{
    		right.Columns.Add(column.Key, column.Value);
    	}
    	right.Columns.Add("float", typeof(float));
    	right.Rows.Add(0, 455, 3000, 67.891, 5);
    	right.Rows.Add(1, 677, 5000, 50.113, 5);
    	right.Rows.Add(2, 778, 5500, 12.672, 6);
    	right.Rows.Add(2, 9000, 5500, 12.672, 6);
    	right.Rows.Add(3, 4, 10, 9.2, 7);
    
    
    	// Compare.
    	DataTable results = Compare(left, right, "emp_num");
    	//results.Dump("Results"); // Fancy table output via LINQPad.
    
    	// Get the comparison columns for display.
    	List<string> comparedColumns = new List<string>();
    	foreach (DataColumn column in results.Columns)
    	{
    		comparedColumns.Add(column.ColumnName);
    	}
    
    	// Display the comparison rows.
    	Console.WriteLine(string.Join(", ", comparedColumns));
    	foreach(DataRow row in results.Rows)
    	{
    		Console.WriteLine(string.Join(", ", row.ItemArray));
    	}
    }
