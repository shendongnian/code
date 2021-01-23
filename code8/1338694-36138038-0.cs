	using (StreamReader streamReader = File.OpenText(path))
	{
		while (!streamReader.EndOfStream)
		{
			string line = streamReader.ReadLine();
			// Process "line" here...
		}
	}
