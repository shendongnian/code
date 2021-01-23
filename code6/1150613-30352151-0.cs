    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
    	// Input array that contains three duplicate strings.
    	string[] array1 = { "cat", "dog", "cat", "leopard", "tiger", "cat" };
    
    	// Display the array.
    	Console.WriteLine(string.Join(",", array1));
    
    	// Use HashSet constructor to ensure unique strings.
    	var hash = new HashSet<string>(array1);
    
    	// Convert to array of strings again.
    	string[] array2 = hash.ToArray();
    
    	// Display the resulting array.
    	Console.WriteLine(string.Join(",", array2));
        }
    }
    
