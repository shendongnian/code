    public class CommandInterceptor : IDbCommandInterceptor
    {
    	public void NonQueryExecuting(
    		DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    	{
    		// do whatever with command.CommandText
    	}
    }
