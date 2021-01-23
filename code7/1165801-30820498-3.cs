    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Test(new Foo());
    		Test(new Bar());
    	}
    	
    	private static void Test(object x)
    	{
    		switch(x.GetType().ToString())
    		{
    			case nameof(Foo):
    				Console.WriteLine("Inside Foo's code");
    			break;
    			
    			case nameof(Bar):
    				Console.WriteLine("Inside Bar's code");
    			break;
    		}
    	}
    }
    
    public class Foo {}
    public class Bar {}
