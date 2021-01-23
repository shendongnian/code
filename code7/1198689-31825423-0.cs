	var lines = text.Split(
		Environment.NewLine.ToCharArray(),
		StringSplitOptions.RemoveEmptyEntries);
	
	var INFO =
		lines[0].Split(',')
			.Zip(lines[1].Split(','), (key, value) => new { key, value })
			.Where(x => !String.IsNullOrEmpty(x.value)
			.ToDictionary.ToDictionary(x => x.key, x => x.value);
