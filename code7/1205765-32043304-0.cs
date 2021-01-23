    string filename = @"c:\myexcel.xlsx"; // your input file.
    string connectionstring = @Provider = Microsoft.ACE.OLEDB.12.0; 
        Data Source = " + filename + @"; Extended properties = 'Excel 12.0; HDR= Yes; ';";
    
    using(var conn = new OleDbConnection(connectionstring)) 
    {
    	conn.Open();
    	var comm = new OleDbCommand("SELECT week, parts FROM [Sheet1$]", conn);
    	var adapter = new OleDbDataAdapter(comm);
    	var ds = new DataSet();
    	adapter.Fill(ds);
    
    	var contents = ds.Tables[0].AsEnumerable().Select(x = > new {
    		week = x.Field < double > ("week"),
    		parts = x.Field < string > ("parts")
    	});
    
    	var result = contents.GroupBy(g = > g.week)
    		.Select(g = > new {week = g.Key, groups = g.GroupBy(s = > s.parts)
    	}).Select(n = > new {
    		n.week, PartAndCount = n.groups.Select(s = > 
    		new 
    		{
    			part = s.Key, count = s.Count()
    		})
    	});
    }
