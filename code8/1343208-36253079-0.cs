    using System;
					
     public class Program
     {
	    public static void Main()
	    {
		    var inputString = "abcd";
		
		    char[] arrChar1 = inputString.ToCharArray();
		    Array.Reverse(arrChar1);
		
		    Console.WriteLine(arrChar1);
	    }
    }
