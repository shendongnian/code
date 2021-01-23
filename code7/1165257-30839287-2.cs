    string destFolder = @"\\server\\dir\";
    string query = "SELECT COUNT(*) FROM Settings WHERE path LIKE @destFolder;";
    
    using (OleDbConnection connection = new OleDbConnection(mdbfile))
    {
    	using (OleDbCommand command = new OleDbCommand(query, connection))
    	{
    		command.Parameters.AddWithValue("@destFolder", "%" + destFolder + "%");
    		try
    		{
    			connection.Open();
    			if ((int)command.ExecuteScalar() == 3)
    			{
    				return true;
    			}
    			else
    			{
    				return false;
    			}
    		}
    		catch (OleDbException ex)
    		{
    			//handle OleDb error
    			return false;
    		}
    	}
    }
