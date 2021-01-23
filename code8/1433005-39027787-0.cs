	static void Main(string[] args)
	{
		// Loading via the command line; parse command line args
		string username = string.Empty;
		string password = string.Empty;
	
		OptionSet CmdParser = new OptionSet
		{
			{ "u|username=", "Username",  u => username = u },
			{ "p|password=", "Password",  p => password = p }
		};
	
		try
		{
			// Loading via the command line; parse command line arguments
			List<string> unknownArgs = CmdParser.Parse(args);
			if (unknownArgs.Count > 1)
			{
				Console.Write("Unrecognised argument in: '{0}'", string.Join(" ", unknownArgs));
			}
		}
		catch (OptionException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
