    public string Insert()
    {
    	var result = String.Empty;
    	SqlConnection Conn = new SqlConnection(@"Data Source=ZARAK\SQLEXPRESS;Initial Catalog=ProjectDAL;integrated security=true");
    
    
    	try
    	{
    		Conn.Open();
    		SqlCommand cmd = new SqlCommand("Insert INTO tbl_User(Name,Email,Password) VALUES ('" + name + "','" + email + "','" + password + "')", Conn);
    
    
    		int restl = cmd.ExecuteNonQuery();
    		//temp = true;
    		result =  "Record Inserted successfully!";
    	}
    	catch (SqlException ex)
    	{
    		if (ex.Number == 2627)
    		{
    			 result = "Record Already Exists";
    		}
            else {
                result = ex.Message; // For other exceptions
            }
    	}
    	finally
    	{
    		Conn.Close();
    	}
    	
    	return result;
    }
