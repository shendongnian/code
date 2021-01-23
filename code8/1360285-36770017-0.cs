    using System;
    
    class Program
    {
        static void Main()
        {
    	const string s = "Dot Net Perls is about Dot Net.";
    	Console.WriteLine(s);
    
    	// We must assign the result to a variable.
    	// ... Every instance is replaced.
    	string v = s.Replace("Net", "Basket");
    	Console.WriteLine(v);
        }
    }
