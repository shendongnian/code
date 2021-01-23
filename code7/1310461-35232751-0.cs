    //If you want to return a DataSet
    public static class SqlDBHelper
    {
    	public static DataSet ExecuteDataSet(string sql, CommandType cmdType, params SqlParameter[] parameters)
    	{
    		using (DataSet ds = new DataSet())
    		using (SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
    		using (SqlCommand cmd = new SqlCommand(sql, connStr))
    		{
    			cmd.CommandType = cmdType;
    			foreach (var item in parameters)
    			{
    				cmd.Parameters.Add(item);
    			}
    
    			try
    			{
    				cmd.Connection.Open();
    				new SqlDataAdapter(cmd).Fill(ds);
    			}
    			catch (Exception ex)
    			{
    				throw ex;
    			}
    			return ds;
    		}
    	}
    	
        //if you want to return a DataTable       
    	public static DataTable ExecuteDataSet(string sql, CommandType cmdType, params SqlParameter[] parameters)
    	{
    		using (DataSet ds = new DataSet())
    		using (SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
    		using (SqlCommand cmd = new SqlCommand(sql, connStr))
    		{
    			cmd.CommandType = cmdType;
    			foreach (var item in parameters)
    			{
    				cmd.Parameters.Add(item);
    			}
    
    			try
    			{
    				cmd.Connection.Open();
    				new SqlDataAdapter(cmd).Fill(ds);
    			}
    			catch (Exception ex)
    			{
    				//Show a message or log a message on ex.Message
    			}
    			return ds.Tables[0];
    		}
    	}	
    	
    }
