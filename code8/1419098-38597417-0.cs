        string value = "Abc\r\n123PQR\r\n456";
    	// Split the string on line breaks.
    	// ... The return value from Split is a string array.
    	string[] lines = Regex.Split(value, "\r\n");
    	foreach (string line in lines)
	    {
	      Console.WriteLine(line);
	    }
   
