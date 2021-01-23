    string connectionString = "** connstr **";
    string query = "SELECT * FROM `table`";
    
    try
    {
    	using (SqlConnection conn = new SqlConnection(connectionString))
    	{
    		using (SqlCommand command = new SqlCommand(query, conn))
    		{
    			string json = command.ExecuteToJson(); 
    		}
    	}
    }
    catch (Exception)
    {
    }
