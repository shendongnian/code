    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		 string sentence = "write LINQ queries to do the following";
    		 int nLastWord = sentence.LastIndexOf(' ');
    		 string strLastWord = sentence.Substring(nLastWord + 1,
    		 	sentence.Length - nLastWord - 1).ToUpper();
    		 	
    		 Console.WriteLine(strLastWord);
    	}
    }
