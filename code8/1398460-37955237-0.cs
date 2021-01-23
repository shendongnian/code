    void Main()
	{
		var regex = new Regex(@"[A-Z][^A-Z]*[AB]?");
		var lines = linesInFile
			.Replace("\\r", "")
			.Split(new[] { '\n' })
			.Where(i => !string.IsNullOrEmpty(i));
			
		var listOfTokens = new List<string>();
		
		foreach (var line in lines)
		{
			foreach (Match match in regex.Matches(line))
			{
				var value = match.Value;
				if (!listOfTokens.Contains(value))
				{
					listOfTokens.Add(value);
				}
			}
		}
		
		listOfTokens.Dump();
	}
	
	// Define other methods and classes here
	
	private string linesInFile = @"Zone1
	Zone1ModuleA
	Zone1ModuleB
	Zone1ModuleAWheel1
	Zone1ModuleAWheel2
	Zone1ModuleBWheel1
	Zone1ModuleBWheel2
	Zone2
	Zone2ModuleA
	Zone2ModuleB
	Zone2ModuleAWheel1
	Zone2ModuleAWheel2
	Zone2ModuleBWheel1
	Zone2ModuleBWheel2";
