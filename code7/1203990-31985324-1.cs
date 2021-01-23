    using (SqlConnection cn = new SqlConnection(cn.ConnectionString))
    {
    	using (SqlCommand cmd = new SqlCommand())
    	{
    		cmd.CommandText = "storedProcedureName";
    		cmd.CommandType = CommandType.StoredProcedure;
    		 cmd.Parameters.Add("@col1", SqlDbType.VarChar).Value = value1;
    		cmd.Connection = cn;
    		cn.Open();
    		int temp = cmd.ExecuteNonQuery();
    
    		if (temp > 0)
    		{
    			Response.Write("Record added successfully");
    		}
    		else
    		{
    			Response.Write("Woops something went wrong!");
    		}
            cn.Close();
    	}
    }
