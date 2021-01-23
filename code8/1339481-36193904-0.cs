	public static string GetProvidedName(string flagPrototype, IEnumerable<string> commandLineArguments)
	{
		IEnumerable<string> flagNames = flagPrototype
			.Split('|')
			.Select(value => value.Replace("=", string.Empty).Replace(":", string.Empty))
			.SelectMany(flagName => 
				new string[] 
				{
					$"-{flagName}",
					$"--{flagName}",
					$"/{flagName}"
				});
		return commandLineArguments.First(argument => flagNames.Contains(argument));
	}
