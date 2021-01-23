    public class Program
    {
    	public static void Main()
    	{
    		Func<string, bool> func = d => true;
    		Process<bool> p = func;
    	    //Process<bool> p = d => true; would result in error
    	}
    }
    
    public class Process<T>
    {
    	public Process(T item)
    	{
    		Item = item;
    	}
    
    	public T Item
    	{
    		get;
    		set;
    	}
    
    	public static implicit operator Process<T>(Func<string, T> func)
    	{
    		return new Process<T>(func("jenish"));
    	}
    }
