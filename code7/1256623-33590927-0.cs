    public interface IFooBar
    {
    	void DoThis();
    }
    
    public class Foo : IFooBar
    {
    	public void DoThis()
    	{
    		//Do something
    	}
    }
    
    public class Bar : IFooBar
    {
    	public void DoThis()
    	{
    		//Do something
    	}
    }
    
    public class C
    {
    	public T func<T>(T obj) where T : IFooBar
    	{
    		obj.DoThis();
    		return obj;
    	}
    }
