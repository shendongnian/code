    using (SqlConnection con = new SqlConnection(_connectionString))
    {
    	using (SqlCommand cmd = new SqlCommand("RemoveDuplicatesTempTable", con))
    	{
    		cmd.CommandType = CommandType.StoredProcedure;
    
    		con.Open();
    		cmd.ExecuteNonQuery();
    	}
    }
