    class EfCommandInterceptor : IDbCommandInterceptor
    {
    	public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    	{
    		GlobalCounter.QueryCount++;
    	}
    	
    	public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    	{
    		GlobalCounter.QueryCount++;
    	}
    	
    	public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    	{
    		GlobalCounter.QueryCount++;
    	}
    	
    	//other methods are empty
    }
