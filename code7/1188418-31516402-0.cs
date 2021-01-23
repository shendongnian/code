    try
    {
    	// Some DB access
    }
    catch (Exception ex)
    {
    	HandleException(ex);
    }
    
    public virtual void HandleException(Exception exception)
    {
    	DbUpdateConcurrencyException concurrencyEx = exception as DbUpdateConcurrencyException;
    	if (concurrencyEx != null)
    	{
    		// A custom exception of yours for concurrency issues
    		throw new ConcurrencyException();
    	}
    
    	DbUpdateException dbUpdateEx = exception as DbUpdateException;
    	if (dbUpdateEx != null)
    	{
    		if (dbUpdateEx != null
    				&& dbUpdateEx.InnerException != null
    				&& dbUpdateEx.InnerException.InnerException != null)
    			{
    				SqlException sqlException = dbUpdateEx.InnerException.InnerException as SqlException;
    				if (sqlException != null)
    				{
    					switch (sqlException.Number)
    					{
    						case 2627:	// Unique constraint error
    						case 547:	// Constraint check violation
    						case 2601:	// Duplicated key row error
    							// Constraint violation exception
    							throw new ConcurrencyException();	// A custom exception of yours for concurrency issues
    
    						default:
    							// A custom exception of yours for other DB issues
    							throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
    					}
    				}
    
    				throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
    			}
    	}
    	
    	// If we're here then no exception has been thrown
    	// So add another piece of code below for other exceptions not yet handled...
    }
