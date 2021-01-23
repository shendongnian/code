	While ((line = myFile.ReadLine()) != null)
	{
		string linecmp = line.toUpper();
		counter++;
		if (linecmp.Contains(userText.toUpper()))
		{
			Console.WriteLine("Found on line number: {0}", counter);
			Console.WriteLine(line.SubString(line.IndexOf(userText),userText.Length));
			found++;
		}
	}
	Console.WriteLine("A total of {0} occurences found", found);
