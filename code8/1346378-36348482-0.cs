    using System;
    
    public class DisposableExample : IDisposable
    {
    	
    	public void Dispose()
    	{
    		Console.WriteLine("Disposed");
    	}
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Before Disposing");
    		using(var disposableObj = new DisposableExample())
    		{
    			Console.WriteLine("Inside Using Statement");
    		}
    		Console.WriteLine("After Disposing");
    	}
    }
