    public DataTable ViewProduct(string id)
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
            conn = new SqlConnection(connStr);
    		conn.Open();
    
    		cmd = conn.CreateCommand();
    		// @id is very important here!
    		// this should really be refactored - SELECT * is a bad idea
    		// someone might add or remove a column you expect, or change the order of columns at some point
    		cmd.CommandText = "SELECT * Products WHERE Idx_ProductId = @id";
    		// this will properly escape/prevent malicious versions of id
    		// use the correct type - if it's int, SqlDbType.Int, etc.
    		cmd.Parameters.Add("@id", SqlDbType.Varchar).Value = id;
    
    		reader = cmd.ExecuteReader();
    		DataTable vpTbl = new DataTable();
    		vpTbl.Load(reader);
    		return vpTbl;
        }
        catch (Exception e)
        {
            // do some meaningful logging, possibly "throw;" exception - don't just return null!
            // callers won't know why null got returned - because there are no rows? because the connection couldn't be made to the database? because of something else?
        }
    	finally
    	{
    		// x?.y is same as if (x != null) then do y
    		reader?.Dispose();
    		cmd?.Dispose();
    	    conn?.Dispose();
    	}
    }
