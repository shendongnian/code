    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	//
    	// String containing numbers.
    	//
    	string sentence = "10 cats, 20 dogs, 40 fish and 1 programmer.";
    	//
    	// Get all digit sequence as strings.
    	//
    	string[] digits = Regex.Split(sentence, @"\D+");
    	//
    	// Now we have each number string.
    	//
    	foreach (string value in digits)
    	{
    	    //
    	    // Parse the value to get the number.
    	    //
    	    int number;
    	    if (int.TryParse(value, out number))
    	    {
    		     Console.WriteLine(number);
    	    }
    	}
        }
    }
