	var series = new List<int>();
	while (true)
	{
		Console.WriteLine("Please pick a number between 1 and 100:");
		series.Add(int.Parse(Console.ReadLine()));
		Console.WriteLine("Do you want to try again (Y/N): ");
		if (Console.ReadLine().ToLower()[0] != 'y')
		{
			break;
		}
	}
	Console.WriteLine("Your numbers are:");
    foreach (var number in series)
	{
		Console.WriteLine(number);
	}
	Console.ReadLine();
