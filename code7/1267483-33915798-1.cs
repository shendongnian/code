    public System.Data.DataTable GetTable(string filename, string SheetName, string outTableName)
    {
    	OleDbConnection oleConn = null;
    	OleDbDataAdapter oleAdapter = null;
    	try
    	{
    		string Con = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
    				     @"Data Source=" + filename + ";" +
    				     @"Extended Properties=" + Convert.ToChar(34).ToString() +
    				     @"Excel 12.0;" + "Imex=1;" + "HDR=Yes;" + Convert.ToChar(34).ToString() ;
    
    		oleConn = new OleDbConnection(Con);
    		oleConn.Open();
    		OleDbCommand oleCmdSelect = new OleDbCommand();
    		oleCmdSelect = new OleDbCommand(
    				@"SELECT * FROM ["
    				+ SheetName
    				+ "$" + "]", oleConn);
    		oleAdapter = new OleDbDataAdapter();
    		oleAdapter.SelectCommand = oleCmdSelect;
    		System.Data.DataTable dt = new System.Data.DataTable(outTableName);
    		oleAdapter.FillSchema(dt, SchemaType.Source);
    		oleAdapter.Fill(dt);
    		oleCmdSelect.Dispose();
    		oleCmdSelect = null;
    		oleAdapter.Dispose();
    		oleAdapter = null;
    		oleConn.Dispose();
    		oleConn = null;              
    		return dt;
    	}
    }
