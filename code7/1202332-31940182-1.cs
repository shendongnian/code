	if (line.StartsWith("    <job_number") && line.EndsWith(">")) {
		int start = line.IndexOf("\"") + 1;
		int end = line.IndexOf("\"", start);
		
		if (start > 0 && end > 0)
		{
			string numberAsString = line.Substring(start, end - start);
			int number;
			if (int.TryParse(numberAsString, out number))
			{
				lines.Add(number);
				//Console.WriteLine(number);
			}
		}
    }
