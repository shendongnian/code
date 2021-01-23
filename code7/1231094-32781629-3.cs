	var lines = File.ReadAllLines(@"C:\YourDirectory\categories.txt");
	var lookup = new List<KeyValuePair<List<string>, Category>>(); //key = parents in order
	foreach (var line in lines)
	{
		var category = new Category (); //line = 3 - First Level 1 -> Second Level 1 -> Third Level 1
		var parts = line.Split('>').ToList(); //3 - First Level 1, Second Level 1, Third Level 1
		category.Id = int.Parse(parts.First().Split('-').First().Trim()); //3
		if (parts.Count > 1) //has parent
		{
			category.Name = parts.Last().Trim(); //Third Level 1
			if (parts.Count == 2) //has one level parent
			{
				var parentStr = parts.First().Split('-').Last().Trim();
				if (lookup.Any(l => l.Value.Parent == null && l.Value.Name == parentStr))
				{
					var parent = lookup.First(l => l.Value.Parent == null && l.Value.Name == parentStr);
					category.Parent = parent.Value;
					lookup.Add(new KeyValuePair<List<string>,Category>(new List<string> { parent.Value.Name }, category));
				}
			}
			else //has multi level parent
			{
				var higherAncestors = parts.Take(parts.Count - 2).Select(a => a.Split('-').Last().Trim()).ToList(); //.GetRange(1, parts.Count - 2).Select(a => a.Trim()).ToList();
				var parentStr = parts.Skip(parts.Count - 2).First().Trim();
				if (lookup.Any(l => MatchAncestors(l.Key, higherAncestors) && l.Value.Name == parentStr))
				{
					var parent = lookup.First(l => MatchAncestors(l.Key, higherAncestors) && l.Value.Name == parentStr);
					category.Parent = parent.Value;
					var ancestors = parent.Key.ToList();
					ancestors.Add(parent.Value.Name);
					lookup.Add(new KeyValuePair<List<string>, Category>(ancestors, category));
				}
			}
		}
		else //no parent
		{
			category.Name = parts.First().Split('-').Last().Trim(); //for 1 - First Level 1
			lookup.Add(new KeyValuePair<List<string>,Category> (new List<string>(), category));
		}
	}
	var categories = lookup.Select(l => l.Value);
