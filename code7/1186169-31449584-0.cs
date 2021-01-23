	int i = 0;
	while (i < limit)
	{
		string value = Console.ReadLine();
		int parsedValue;
		
		if (!int.TryParse(value, out parsedValue))
		{
			Console.WriteLine("You've entered an invalid number. Please try again");
			continue;
		}
		
		array[i] = parsedValue;
		i++;
	}
	
