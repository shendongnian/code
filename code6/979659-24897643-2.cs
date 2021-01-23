    using (var cn = new SqlConnection("connection string"))
    {
    	cn.Open();
    	using (var cmd = cn.CreateCommand())
    	{
            // Add your paramters to the command object.
    
    		using (var reader = cmd.ExecuteReader())
    		{
    
    			while (reader.Read())
    			{
    				txtID.Text = myReader["ID"].ToString();
    			}
    		}
    	}
    }
