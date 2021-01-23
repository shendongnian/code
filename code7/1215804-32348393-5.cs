	var lines = new List<string>();
	using (var stream = new FileStream(@"c:\tmp\locked.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
	{
		using (var reader = new StreamReader(stream, Encoding.UTF8))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				lines.Add(line);
			}
		}
	}
	// Now you have a List<string>, which can be converted to a string[] if you really need one.
	var stringArray = lines.ToArray();
