    public class BaseClass
    {
    	public void SomeMethod()
    	{
    		var thing = new ChildClass();
    		try
    		{
    		    thing.ThrowMyException();
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine("Exception caught: " + ex.Message);
    		}
    	}
    }
    
    public class ChildClass : BaseClass
    {
    	public void ThrowMyException()
    	{
    		throw new Exception("Oh no!");
    	}
    }
