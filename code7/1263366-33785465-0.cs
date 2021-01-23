    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Testing string[]");
    		var test = new string[1] {"example"};
    		Example(test);
    		
    		Console.WriteLine();
    		Console.WriteLine("Testing int[]");		
    		var test2 = new int[1] {0};
    		Example(test2);
    	}
    	
    	public static void Example(params object[] test)
    	{
    		Console.WriteLine("Array Type: {0}", test.GetType());
    		Console.WriteLine("test[0] Type: {0}", test[0].GetType());
    			
    	}
    	
    }
