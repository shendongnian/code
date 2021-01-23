    static void FullDirList(
		DirectoryInfo dir, string searchPattern, string excludeFolders, int maxSz, int depth)
    {
		var results =
			from fi in GetFullDirList(dir, searchPattern, depth)
			where String.IsNullOrEmpty(excludeFolders)
				|| !Regex.IsMatch(fi.FullName, excludeFolders, RegexOptions.IgnoreCase)
			group fi.FullName by fi.Directory.FullName;
		
		var directoriesFound = results.Count();
		var filesFound = results.SelectMany(fi => fi).Count();
		
		var aggregateByLength =
			results
				.SelectMany(fi => fi)
				.Aggregate(new [] { new StringBuilder() }.ToList(),
					(sbs, s) =>
					{
						var nl = s + Environment.NewLine;
						if (sbs.Last().Length + nl.Length > maxSz)
						{
							sbs.Add(new StringBuilder(nl));
						}
						else
						{
							sbs.Last().Append(nl);
						}
						return sbs;
					});
		
		foreach (var sb in aggregateByLength)
		{
			File.WriteAllText(nextOutPutFile(), sb.ToString());
		}
    }
