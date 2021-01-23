    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    int[] myArray = new int[] { 1,2,3,4,5 };
		
		    foreach(var item in myArray)
		    {
			    Console.WriteLine(String.Join(",", item));
		    }
	    }
    }
