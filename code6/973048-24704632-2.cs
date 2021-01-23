    // a method with a class that manages the Command (_Command) and Connection objects 
    public async Task<List<TOut>> ExecuteReaderAsync<TOut>(IResultSetMapper<TOut> resultsMapper)
    {
    	List<TOut> results = null;
    	try
    	{
    		using(var connection = await _DbContext.CreateOpenedConnectionAsync())
    		{
    			_Command.Connection = connection;
    
    			// execute the reader and iterate the results; when done, the connection is closed
    			using(var reader = await _Command.ExecuteReaderAsync())
    			{
    				results = await resultsMapper.MapSetAsync(reader);
    			}
    		}
    		return results;
    	}
    	catch(Exception cmdEx)
    	{
    		// handle or log exception...
    		throw;
    	}
    }
