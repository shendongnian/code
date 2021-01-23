    using System;
    class Program
    {
    static void Main()
    {
	// The input string.
	const string value = "Your dog is cute.";
	// Test with IndexOf method.
	if (value.IndexOf("dog") != -1)
	{
	    Console.WriteLine("string contains dog!");
	}
    }
    } 
