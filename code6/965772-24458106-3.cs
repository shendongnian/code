    public class BaseClass
    {
    	public void SomeMethod()
    	{
    		try
    		{
    			SomeOtherMethod();
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine("Caught Exception: " + ex.Message);
    		}
    	}
    	
    	public virtual void SomeOtherMethod()
    	{
    		Console.WriteLine("I can be overridden");
    	}
    }
    
    public class ChildClass : BaseClass
    {
    	public override void SomeOtherMethod()
    	{
    		throw new Exception("Oh no!");
    	}
    }
    	
