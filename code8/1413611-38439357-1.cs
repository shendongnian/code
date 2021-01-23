    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		IDisposable foo = new Foo();
            Bar bar = (Bar)foo;
    	}
    }
    
    public class Foo : IDisposable 
    {
    	public void Dispose()
    	{
    	}
    }
    
    public sealed class Bar
    {
    }
