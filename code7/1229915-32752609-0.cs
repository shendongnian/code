    string conString = "xxxxxxxxxxxxxxxxxxxxxxxx";
    using (SqlConnection con = new SqlConnection(conString))
    {
    	con.Open();
    	using (var cmd = new SqlCommand(
    	"SELECT * FROM Login Where Username=@Username AND Password=@Password",
    	con))
    	{
    		cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
    		cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
    
    		using (SqlDataReader reader = cmd.ExecuteReader())
    		{
    			if (reader.HasRow())
    			{
    				if(reader.Read())
    				{
    					var username = reader["Username"].ToString();
    				}
    			}
    			else
    			{
    				//User does not exists
    			}
    		} 
    	}
    }
