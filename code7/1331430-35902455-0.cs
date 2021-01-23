    using(var conn = new SqlConnection(<connection string here>))
    {
    	try
    	{
    		conn.Open();
    		string sql = "<sql query here>";
    		using(var cmd = new SqlCommand(sql,conn))
    		{
    			using(var reader = cmd.ExecuteReader())
    			{
    				if(reader.HasRows)
    				{
    					while(reader.Read())
    					{
    						//Here is where you get your data..
                            int imReadingAnInt = (int)reader["myIntColumnHeader"];
                            string imReadingAString = reader["myStringColumnHeader"].ToString();
    					}
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		string err = ex.Message;
    	}
    }
