    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
	    public static void Main(String[] args)
	    {
		   string[] array1 = "I want to find item2 or item6".Split(' ');
		   string[] array2 = {"item1", "item2", "item6"};
	
		   IEnumerable<string> results = array1.Intersect(array2,
                                                         StringComparer.OrdinalIgnoreCase);
		
		   foreach (string s in results)
			  Console.WriteLine("{0} was found at index {1}.", 
                                s, 
                                Array.IndexOf(array2, s));
	
	    }
    }
