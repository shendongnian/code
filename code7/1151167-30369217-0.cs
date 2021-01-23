	List<string> allFilesWords = new List<string>();
    foreach (var filename in file)
    {
		var fileQuery = File.ReadLines(filename)
			.SelectMany(line => line.Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries))
			.AsParallel()
			.Select(word => word.ToLower())
			.Where(word => !word.All(char.IsDigit)));
		allFilesWords.AddRange(fileQuery.Distinct());
	}
	return allFilesWords
			.GroupBy(word => word)
			.ToDictionary(g => g.Key, g => g.Count());       
