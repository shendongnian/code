    public class ExceptionLogger : IInterceptor
    {
    	private readonly TextWriter _output;
    	
    	public ExceptionLogger(TextWriter output)
    	{
    		_output = output;
    	}
    	
    	public void Intercept(IInvocation invocation)
    	{
    		try
    		{
    			invocation.Proceed();
    		}
    		catch(Exception ex)
    		{
    			_output.WriteLine("Logged Exception: {0}", ex.Message);
    			throw;
    		}
    	}
    }
