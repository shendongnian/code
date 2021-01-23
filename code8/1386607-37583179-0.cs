    public void TestMethod()
    {
        string cmdStr = "<some sql command text>";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(cmdStr, con);
    	cmd.Parameters.AddWithValue("<param1>", <value1>); // add parameter in any way you want
    #if DEBUG
    	string parsedQuery = cmd.GetParsedQuery();
    	Console.WriteLine(parsedQuery); // or whatever
    #endif	
    	SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;
    }
    
    public static string GetParsedQuery(this SqlCommand cmd)
    {
    	if(cmd.CommandType == CommandType.Text)
    	{
    		string parsedQuery = cmd.CommandText;
    		foreach(var p in cmd.Parameters)
    		{
    			parsedQuery = parsedQuery.Replace(p.ParameterName, Convert.ToString(p.Value));
    		}
    		
    		return parsedQuery;
    	}
    	
    	return null;
    }
