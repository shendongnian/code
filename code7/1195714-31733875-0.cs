    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		try
    		{
    		string d = "2015-07-29T19:55:10.994sdfsdf";
    		DateTime dt = Convert.ToDateTime(d);
    		
    		Console.WriteLine(dt);
    		}
    		catch(FormatException)
    		{
    			Console.WriteLine(" Date is InValid ");
    		}
    	}
    }
