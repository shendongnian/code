    static void LogParameters(string[] args)
    {
		string msg = string.Empty;
		foreach(var item in args)
		{
			var subParts = item.Split(new[] { '=' },  
						   StringSplitOptions.RemoveEmptyEntries);
			if (subParts[0] != "-password")
				msg += item + " ";
			else
				msg += subParts[0] + "****** ";
		}
	   Console.WriteLine("Command line parameters: {0}",msg.TrimEnd());
    }
