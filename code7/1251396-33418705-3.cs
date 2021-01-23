	var names = new List<string>();
	var input = Console.ReadLine();
	
	while (input.ToUpper() != "X")
	{
		names.Add(input);
		input = Console.ReadLine();
	}
	
	foreach (var name in names)
	{
		Console.WriteLine(name);
	}
