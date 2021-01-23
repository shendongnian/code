	using (var stream = new FileStream(@"c:\tmp\locked.txt", FileMode.Open, FileAccess.Read))
	{
		using (var reader = new StreamReader(stream, Encoding.UTF8))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				// Do something with line, e.g. add to a list or whatever.
				Console.WriteLine(line);
			}
		}
	}
