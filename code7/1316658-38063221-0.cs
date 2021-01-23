    int rowCount = 0; // In case you want the number of rows affected
    try
    {
    	if (conn.State != ConnectionState.Open)
    		conn.Open();
    					
    	MySqlCommand command = new MySqlCommand(query, conn);	
				
    	using(var transaction = conn.BeginTransaction(iLevel))
    	{	
    		command.Transaction = transaction;                 
    		command.CommandTimeout = int.MaxValue;
    		
    		// Set parameters etc...
    		
    		try
    		{
    			rowCount = command.ExecuteNonQuery();
    			transaction.Commit();
    		}
    		catch(Exception ex)
    		{
    			transaction.Rollback();			
    			// Handle query exception...			
    		}
    	}
    }
    catch(Exception ex)
    {
    	// Handle general exception...
    }
