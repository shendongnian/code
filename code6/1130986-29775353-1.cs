	...
	// For each colour in our team colours but not in our model colours, remove
	foreach (var colour in team.Colours.ToList()) // <<== note change here
		if (!model.Colours.Any(c => c.Id == colour.Id))
			team.Colours.Remove(colour);
	// For each colour that has to be added, add to our team colours
	if (model.Colours != null)
		foreach (var colour in model.Colours.ToList()) // <<== note change here
			if (!team.Colours.Any(c => c.Id == colour.Id))
				team.Colours.Add(colours.Where(m => m.Id == colour.Id).SingleOrDefault());
	...
