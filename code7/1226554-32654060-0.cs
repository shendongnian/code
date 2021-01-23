	var original = "MY FILE = \"/test/test.txt\" VERSION = 3 CRC = 0x1ECC2C78 XYZ = ABC VERSION = \"NOT APPLICABLE\"";
	var nameToRemove = "VERSION";
	var stringBuilder = new StringBuilder();
	
	var s = original;
	while(s.Length>0)
	{
		var getNameRegex = new Regex("(.*?)=");
		var name = getNameRegex.Match(s).Groups[1].ToString();
		s = s.Substring(name.Length+1);
		Regex getValueRegex;
		if (s.TrimStart().StartsWith("\""))
		{
			getValueRegex =new Regex("(\\s*\".*?\"\\s*)");
		}
		else
		{
			getValueRegex =new Regex("(\\s*.*?)\\s+");
		}
		var value = getValueRegex.Match(s).ToString();
		s = s.Substring(value.Length);
		
		if (name.Trim() != nameToRemove)
		{
			stringBuilder.Append(name).Append("=").Append(value);
		}	
	}
	Console.WriteLine ("original : {0}",original);
	Console.WriteLine ("parsed   : {0}",stringBuilder.ToString());
