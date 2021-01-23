	var linesInFile = File.ReadAllLines();
	var newLines = new List<string>();
	var toRandomize = new List<string>();
	bool inRegion = false;
	for (int i = 0; i < linesInFile.Count; i++)
	{
		string line = linesInFile[i];
		if (line == "[RAND]")
		{
			inRegion = true;
			continue;
		}
		if (line == "[/RAND]")
		{
			inRegion = false;		
			// End of random block.
            // Now randomize `toRandomize`, add it to newLines and clear it		
			newLines.AddRange(toRandomize);
			toRandomize.Clear();
			continue;
		}
		
		if (inRegion)
		{
			toRandomize.Add(line);
		}
		else
		{
			newLines.Add(line);
		}
	}
    File.WriteAllLines(newLines, ...);
