	// -1, 0, ..., 5
	var choices = Enumerable.Range(-1, 6); 
	
	var possibleChoices = 
		from a in choices
		from b in choices
		from c in choices
		from d in choices
		from e in choices
		select (IEnumerable<int>)new [] { a, b, c, d, e };
	
	// Remove -1's because they represent not being in the choice.
	possibleChoices =
		possibleChoices.Select(c => c.Where(d => d >= 0));
	
	// Remove choices that have non-unique digits.
	possibleChoices =
		possibleChoices.Where(c => c.Distinct().Count() == c.Count());
	
	// Sort the choices to indicate order doesn't matter
	possibleChoices =
		possibleChoices.Select(c => c.OrderBy(d => d));
	
	// Remove duplicates
	possibleChoices = 
		possibleChoices.Select(c => new 
							   {
								   Key = string.Join(",", c),
								   Choice = c
							   }).
		GroupBy(c => c.Key).
		Select(g => g.FirstOrDefault().Choice);
	
	foreach (var choice in possibleChoices) {
		Console.Out.WriteLine(string.Join(", ", choice));
	}
