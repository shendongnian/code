	private void CreateJS(string jsPath, string[] contents)
	{
		File.Create(jsPath)
		StreamWriter sw = new StreamWriter(jsPath);
		
		foreach (string s in contents)
		{
			sw.WriteLine(s);
		}
	}
