    public interface IFoo
    {
    	void DoWork(params object [] arguments);
    }
    
    public class Foo : IFoo
    {
    	public void DoWork(params object [] arguments)
    	{
    		string a = (string)arguments[0];
    		int b = (int)arguments[1];
    		string c = (string)arguments[2];
    		long d = (long)arguments[3];
    		
    		Console.WriteLine("a={0}, b={1}, c={2}, d={3}", a,b,c,d);
    	}
    }
    
    public class AnotherFoo : IFoo
    {
    	public void DoWork(params object [] arguments)
    	{		
    		int e = (int)arguments[0];
    		string f = (string)arguments[1];
    		string g = (string)arguments[2];
    		
    		Console.WriteLine("e={0}, f={1}, g={2}", e,f,g);
    	}
    }
    
    void Main()
    {
    	var foo = new Foo();	
    	foo.DoWork("a",1, "c",2L);
    	
    	var foo1 = new AnotherFoo();	
    	foo1.DoWork(1,"f", "g");
    }
