	Console.Write("What is the price?"); 
	string input = Console.ReadLine(); // keep as string
	double pricenumber;
	while (!decimal.TryParse(input, out pricenumber))
	{
		Console.WriteLine("You've not entered a price.\r\nPlease enter a price");
		input = Console.ReadLine();
	}
