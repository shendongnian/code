    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);     
    		
    		string test = "lorem tst a btst c tst tst tst tst a";
    		Console.WriteLine(regex.Replace(test.Replace("tst", ""), @" "));
    	}
    }
