	Console.WriteLine();
	Console.WriteLine("~~~~~~~~~~~~~~~~");
	Console.WriteLine("Number Frequency");
	
	var allRolls = firstDice.Concat(secondDice).ToList();	
	for(var i = 1; i <= 6; i++)
	{
		Console.Write(i + ": ");
		for(var j = 0; j < allRolls.Count(c => c == i); j++)
			Console.Write("|");
		Console.WriteLine();
	}
