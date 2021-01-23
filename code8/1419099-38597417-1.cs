        string value = "Abc\r\n123PQR\r\n456";
    	// Split the string on line breaks.
    	// ... The return value from Split is a string array.
    	string[] lines = Regex.Split(Regex.Replace(value, @"[\d]", string.Empty), "\r\n");
    	foreach (string line in lines)
	    {
	      Console.WriteLine(line);
	    }
   
