    static string[] GetTableNames( DataSet ds)
    {
    	List<string> tablenames = new List<string>();
    
    	// The first Table contains the TABLE NAMES
    	tablenames.Add("TableNames"); 
    
    	if (ds.Tables[0].Rows.Count > 0)
    		foreach( DataRow row in ds.Tables[0].Rows)
    		{
    			tablenames.Add(row["TableName"].ToString());
    		}
    
    	return tablenames.ToArray();
    }
