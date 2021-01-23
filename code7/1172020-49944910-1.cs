    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var cl = new MyClass();
    		
    		Console.WriteLine("Executing method off Object");
    		Console.WriteLine("--------------------------------");
    		
    		cl.MyMethod();
    		
    		Console.WriteLine("");
    		Console.WriteLine("");
    		Console.WriteLine("Executing method through Casting");
    		Console.WriteLine("--------------------------------");
    		
    		(cl as IMyInterface).MyMethod();
    		
    	}
    }
    
