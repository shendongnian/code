    List<string> lines = new List<string>();
    
    using (var file = new StreamReader(fileName))
    {
    	string line = string.empty;
    	while ((line = file.ReadLine()) != null)
    	{
    		if (line[0] == chr)
    		{
    			lines.Add(line);
    		}
    	}
    }
    
    Console.WriteLine(lines.Count);
