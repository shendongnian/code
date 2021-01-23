    public class C<T> 
    {
    	public T _t { get; set; }
    	
    	public C(T t)
    	{
    		_t = t;
    	}
    	
    	public void TestMethod()
    	{
    		Console.WriteLine(_t.ToString());
    	}
    }
    public class X
    {
    	public void M()
    	{
    	
    		var V = new { W = 1 };
    		
    		var X = new C<object>(V); // everything is an object.
    		
    		X.TestMethod();
    	}
    }
