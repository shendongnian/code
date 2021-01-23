    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		RegexOptions options = RegexOptions.None;
    		Regex regex = new Regex(@"[ ]{2,}", options);     
    		
    		string test = "lorem tst a btst c tst tst tst tst a";
    		Console.WriteLine(regex.Replace(test.Replace("tst", ""), @" "));
    	}
    }
