	static void ReadFile()
	{
		List<string> lines = new List<string>();
		if (File.Exists(INPUT_FILE_NAME))
		{
			using(var sr = new StreamReader(INPUT_FILE_NAME))
			{
				string line;
				while((line = sr.ReadLine()) != null)
				{
					lines.Add(line);
				}
			}
		}
		else
		{
			Console.WriteLine("Error: {0} does not exist\n",INPUT_FILE_NAME);
			ConsoleApp.Exit();
		}
		// you now have a list of numbers as strings here (lines)
		// You need to parse and assign these to your numArray
		// Hint: for loop and Parse/TryParse
	}
	
