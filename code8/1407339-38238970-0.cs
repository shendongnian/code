        DataTable dt = new DataTable(); // Create DataTable
    	
    	dt.Columns.Add("A", typeof(int)); // Add a Column
    	dt.Columns["A"].DefaultValue = 5; // Set Column default value
    	
    	dt.Rows.Add(3); // Add a DataRow
    
    	DataTable dt1 = new DataTable(); // Create DataTable
    
    	dt1.Columns.Add("C", typeof(int)); // Add a Column
    	dt1.Columns["C"].DefaultValue = 5; // Set Column default value
    
    	dt1.Rows.Add(3); // Add a DataRow
    
    	dt.Merge(dt1); // Merge dt1 into dt
