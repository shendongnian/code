	string input;
	int value;
	
	while (true) {
		Console.WriteLine("Type in some text: ");
		input = Console.ReadLine();
		
		if (!int.TryParse(input, out value))  // TryParse failed, we're good
		{
			Console.WriteLine(input);
			break;
		}
		
		Console.WriteLine("Please type in some text without numbers");
	}
