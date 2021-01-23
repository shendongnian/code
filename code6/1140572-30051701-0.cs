    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string string1 = "CZSczs";
    		string string2 = "ČŽŠčžš";
    		
    		if(String.Compare(string1, string2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
    		{
    		Console.WriteLine("same");
    		}
    		else
    		{
    		Console.WriteLine("not same");
    		}
    		
    	}
    }
