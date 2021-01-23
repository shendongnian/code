    using (SqlConnection sourceCnx = new SqlConnection(SOURCE_CONN_STRING))
        {
            try
    		{
    			sourceCnx.Open();
    			SqlCommand sysCmd = sourceCnx.CreateCommand();
    			sysCmd.CommandText = "My query";
    			sysCmd.ExecuteNonQuery();
    		}
    		catch (SqlException e)
    		{
    			// This will catch any SQL Exceptions.
                // Use "throw;" if you want to rethrow the exception up the stack
    		}
    		catch (Exception e)
    		{
    			// This will catch any other exceptions.
                // Use "throw;" if you want to rethrow the exception up the stack
    		}
    	} 
