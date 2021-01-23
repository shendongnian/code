	int amount = 20000;
	int choice, pin = 0, x = 0;
	Console.WriteLine("Enter your pin");
	pin = int.Parse(Console.ReadLine());
	Console.WriteLine("welcome to HSPUIC bank would you like to make a withdraw today N or Y");
	// save user input
	var userInput = Console.ReadLine();
	// evaluate if user wants to continue or not
	if (userInput.ToLower() == "y")
	{
		// if yes, go further
		Console.WriteLine("continue with other action...");
	}
	// else bye
	Console.WriteLine("goodbye");
