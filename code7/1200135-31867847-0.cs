	string[] beverages = new string[]
	{
		"Cola", "Sprite", "Fanta", "Bitter Lemon", "Beer"
	};
	
	Console.WriteLine("Please choose your favorite beverage");
	for (int i = 0; i < beverages.Length; i++)
	{
   		Console.WriteLine("For {0} type '{1}'", beverages[i], i + 1);
	}
	
	bool correct = false;
	while (!correct)
	{
		int input = 0;
		if (int.TryParse(Console.ReadLine(), out input))
		{
			correct = Enumerable.Range(1, beverages.Length).Contains(input);
		}
		if (correct)
		{
			Console.WriteLine("Enjoy your {0}!", beverages[input - 1]);
		}
		else
		{
			Console.WriteLine("That is not a valid input!");
		}
	}
