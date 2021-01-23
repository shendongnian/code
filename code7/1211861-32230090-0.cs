    string sql = "select date  from guest,program where guestid=guest.id AND date >= @date";
    
    using (MySqlConnection con = new MySqlConnection("your connectionstring"))
    {
    	MySqlCommand cmd = new MySqlCommand(sql, con); 
    
    	try 
    	{ 
    		con.Open(); 
    		cmd.Parameters.AddWithValue("date", date); 
    		
    		using (var reader = cmd.ExecuteReader())
    		{
    			while (reader.Read())
    			{
    				var dateField = (DateTime)reader["date"];
    				// some task
    			}
    		}
    	} 
    	finally 
    	{ 
    		con.Close(); 
    	}
    }
    	
