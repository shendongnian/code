	Console.WriteLine("Start");
	if (results == null || !results.Any())
		Console.WriteLine("No result received!");
	foreach (var result in results)
	{
		Console.WriteLine("new result-set");
		if (result == null || !result.Any())
			Console.WriteLine("    Result: Empty list!");
		foreach (var individualresult in result)
		{
			Console.WriteLine("   Result: " + individualresult);
		}
	}
	Console.WriteLine("End");
	Console.Readline();
