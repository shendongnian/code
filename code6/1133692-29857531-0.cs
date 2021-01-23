    values
    .Aggregate(
	new { HashSet1 = new HashSet<string>(), HashSet2 = new HashSet<string>() },
	(a, x) =>
	{
        // If the last character is a lowercase letter then put the string
        // (minus the last character) in HashSet1, otherwise, put the string
        // in HashSet2
		if(Char.IsLower(x, x.Length - 1))
		{
			a.HashSet1.Add(x.Substring(0, x.Length - 1));
		}
		else
		{
			a.HashSet2.Add(x);
		}
		return a;
	},
	a => 
	{
        // Return all the strings that are present in both hash sets.
		return 
		a
		.HashSet1
		.Where(x => a.HashSet2.Contains(x));
	});
