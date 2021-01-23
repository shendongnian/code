	Console.WriteLine();
	Console.WriteLine("~~~~~~~~~~~~~~~~");
	Console.WriteLine("Number Frequency");
	
	foreach(var rollNumber in firstDice.Concat(secondDice).GroupBy (d => d).OrderBy(d => d.Key))
	{	
		Console.Write(rollNumber.Key + ": " );
		for(var i = 0; i < rollNumber.Count(); i ++)
			Console.Write ("|");
		Console.WriteLine();
	}
