    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string str = "name (12345)";
    		MatchCollection mc = Regex.Matches(str, "[0-9]+");
            int a = int.Parse(mc[0].ToString());
            Console.WriteLine(a);
    	}
    }
