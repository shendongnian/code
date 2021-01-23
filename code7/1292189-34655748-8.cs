	foreach (char c in "bәse")
		Console.Write(((int)c).ToString("0000"));
	
	Console.WriteLine("\n--------------------");
	
	foreach (char c in "bəse")
		Console.Write(((int)c).ToString("0000"));
		
	Console.WriteLine("\n--------------------");
	
	Console.WriteLine(("bәse"=="bəse").ToString());
