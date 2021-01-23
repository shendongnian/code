    using System;
    using System.Diagnostics;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var foo = new Foo { Bar = new Bar { Baz = "Hello" } };
    		var foo1 = new Foo();
    		
    		var i = foo._(_=>_.Bar)._(_=>_.Baz);			//equivalent to foo?.Bar?.Baz in C# 6		
    		Console.WriteLine("i is '{0}'", i);				//should be 'Hello'
    		
    		var j = foo1._(_=>_.Bar)._(_=>_.Baz);			//equivalent to foo1?.Bar?.Baz in C# 6		
    		Console.WriteLine("j is '{0}'",j);				//should be '' since j is null, but shouldn't throw exception either.
    		
    		Console.WriteLine("js is null? {0}", j == null);
    		
    	}
    }
    
    public class Foo 
    {
    	public Bar Bar { get; set; }
    }
    
    public class Bar
    {
    	public string Baz { get; set; }
    }
    
    public static class ObjectExtension
    {
    	//Probably not a good idea to name your method _, but it's the shortest one I can find, I wish it could be _?, but can't :(
    	public static K _<T, K>(this T o, Func<T, K> f) 
    	{
    		try 
    		{
    			var z = f(o);
    			return z;			
    		}
    		catch(NullReferenceException nex) 
    		{
    			Trace.TraceError(nex.ToString());
    			return default(K);
    		}
    		
    	}
    }
