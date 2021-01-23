     using System;
     using System.Collections.Generic;
    class Program
    {
     static void Main()
     {
	  Dictionary<string, string> test = new Dictionary<string, string>();
	  test.Add("one", "value");
	//
	// Use TryGetValue to avoid KeyNotFoundException.
	//
	string value;
	if (test.TryGetValue("two", out value))
	{
	    Console.WriteLine("Found");
	}
	else
	{
	    Console.WriteLine("Not found");
	}
      }
    }
