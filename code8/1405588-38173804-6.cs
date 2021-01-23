    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Action a = null;
    		for (int index = 0; index < 10; index++)
    			a = () => Console.WriteLine(index);
    			
    		a();
    	}
    }
