    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string name = "Jesse";
            int courseNum = 230;
            int num = 23130;
            decimal d = 123456789.54321M;
    
            string combined = name + courseNum + num + d;
    		foreach (char c in combined)
    		{
    			Console.Write("{0} ", Convert.ToString(c, 2).PadLeft(8, '0'));
    		}
    	}
    }
