	var reader = new StringReader(test);
	reader.ReadLine();
	string line;
	while ((line = reader.ReadLine()) != null)
	{
		Console.WriteLine(line);
	}
	Console.ReadLine();
