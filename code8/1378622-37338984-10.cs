	Console.Write("How many were you planning on purchasing?"); 
	amount = decimal.Parse(Console.ReadLine()); // you're already parsing the string into a
    // decimal
	while (amount == string.Empty) // as you can't compare a decimal with a string, this 
    // creates an error
	{
		Console.WriteLine("You cannot leave this blank.\r\nPlease enter how many are needed:");
		amount = decimal.Parse(Console.ReadLine());
	}
