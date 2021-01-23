	// F1
	if (input.Key == ConsoleKey.F1)
	{
		Console.Write("Insert World's name: ");
		worldName = Console.ReadLine();
	}
	// F2
	else if (input.Key == ConsoleKey.F2)
	{
		Console.WriteLine("Loading World: {0}", worldName);
	}
