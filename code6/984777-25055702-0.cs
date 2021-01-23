    string text = "This is * test string";
    Regex regex = new Regex(@"\*");
	string[] substrings = regex.Split(text);
	string output = "";
	foreach (string match in substrings)
	{	
	    output += match;
    }
    Console.WriteLine(output);
