    // Check for duplicates
	if (data != null)
	{
		var grp =
			data.GroupBy(
				g =>
					new 
					{ 
						g.GroupID,
						g.StrategyID
					},
				(key, group) => new 
					{ 
						GroupID = key.GroupID,
						StrategyId = key.StrategyID,
						Count = group.Count() 
					});
		
		if (grp.Any(c => c.Count > 1))
		{
			Console.WriteLine("Duplicate exists");
			// inside the grp object, you can find which GroupID/StrategyID combo have a count > 1
		}
	}
