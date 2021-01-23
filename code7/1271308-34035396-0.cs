	const int itemCount = 3;
	List<int> inputValues = new List<int>(itemCount);
		
	while(inputValues.Count < itemCount)
	{
		Console.WriteLine("Enter a value: ");
		int parsed; 
		if(int.TryParse(Console.ReadLine(), out parsed))
			inputValues.Add(parsed);
		else
			Console.WriteLine("Please try again!");
	}
