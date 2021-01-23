        using System;
        using System.Text.RegularExpressions;
        
        public class Test
        {
        	public static void Main()
        	{
        		string str = "name (12345)";
        		MatchCollection mc = Regex.Matches(str, "[0-9]+");
                 foreach (Match m in mc)
                 {
                    Console.WriteLine(m);
                 }
    	   }
        }
