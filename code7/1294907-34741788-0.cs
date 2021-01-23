    using System;
    
    class Program
    {
        static void Main()
        {
    	// Create three-item tuple.
    	Tuple<int, string, bool> tuple =
    	    new Tuple<int, string, bool>(1, "cat", true);
    	// Access tuple properties.
    	if (tuple.Item1 == 1)
    	{
    	    Console.WriteLine(tuple.Item1);
    	}
    	if (tuple.Item2 == "dog")
    	{
    	    Console.WriteLine(tuple.Item2);
    	}
    	if (tuple.Item3)
    	{
    	    Console.WriteLine(tuple.Item3);
    	}
        }
    }
