    void Main()
    {
    	try
    	{
    		Activator.CreateInstance(typeof(Foo));
    	}
    	catch(Exception e)
    	{
    		e.Message.Dump();
    		e.GetType().Name.Dump();
    	}
    }
    
    public class Foo
    {
    	public Foo()
    	{
    		throw new AuthorizationFailedException();
    	}
    }
    
    public class AuthorizationFailedException : Exception
    {
    
    }
