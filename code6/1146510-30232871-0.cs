    using System;
    using System.Diagnostics;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var foo = new Foo { Bar = new Bar { Baz = "Hello" } };
    		var foo1 = new Foo();
    		
    		var i = foo.Val<Foo, Bar>(f => f.Bar).Val<Bar, string>(b => b.Baz);
    		Console.WriteLine(i);
    		
    		var j = foo1.Val<Foo, Bar>(f => f.Bar).Val<Bar, string>(b => b.Baz);
    		Console.WriteLine(j);
    		
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
    	public static K Val<T, K>(this T o, Func<T, K> f) 
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
