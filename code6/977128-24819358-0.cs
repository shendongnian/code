    string s = "2.4 kWh @ 105.00 c/kWh";
	//
	// Split string on spaces.
	// ... This will separate all the words.
	//
	string[] words = s.Split(' ');
	foreach (string word in words)
	{
	    Console.WriteLine(word);
	}
