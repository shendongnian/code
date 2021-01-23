    string s = "2.4 kWh @ 105.00 c/kWh";
	string[] words = s.Split(' ');  // Split string on spaces.
	foreach (string word in words)
	{
	    Console.WriteLine(word);
	}
