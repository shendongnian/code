	string input = "hello world";
	byte[] inputBytes = ASCIIEncoding.ASCII.GetBytes(input);
		
	// Decimal display
	Console.WriteLine(String.Join(" ", inputBytes));
		
	// Hex display
	Console.WriteLine(String.Join(" ", inputBytes.Select(ib => ib.ToString("X2"))));
		
	// Binary display
	Console.WriteLine(String.Join(" ", inputBytes.Select(ib => Convert.ToString(ib, 2))));
