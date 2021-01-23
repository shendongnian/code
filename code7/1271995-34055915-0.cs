	string worldName = string.Empty;
	// wait for keypress, don't display it to the user
	// If you want to display it, remove the 'true' parameter
	var input = Console.ReadKey(true);
	// test the result
	if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)
	{
		Console.Write("Insert World's name: ");
		worldName = Console.ReadLine();
	}
	else if (input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2)
	{
		Console.WriteLine("Loading World: {0}", worldName);
	}
