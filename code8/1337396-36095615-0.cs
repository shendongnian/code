	string s = "Alex Amonov,Semen Polov,John S,Alex Solid";
	
	// split original list into separate names
	var names = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
	
	// split names into first-last pairs, and group by matching first names groups,
    // preserving information about original order/index
	var nameGroups = names.Select((n, i) => Tuple.Create(i, n.Split(' '))).GroupBy(n => n.Item2[0]).ToList();
	
	// prepare output array to store final names in original order
	var result = new string[names.Length];
	
	foreach (var nameGroup in nameGroups)
	{
		// if only one matching first name in group, output just the first name
		if (nameGroup.Count() == 1)
		{
			result[nameGroup.Single().Item1] = nameGroup.Single().Item2[0];
		}
		else
		{
			// if multiple matching names, include first letter of last name
			foreach (var entry in nameGroup)
			{
				result[entry.Item1] = entry.Item2[0] + " " + entry.Item2[1][0];
			}
		}
	}
	
	// generate output comma-separated list of final output names in original order
	var output = string.Join(" , ", result);
	Console.WriteLine(output);		// Alex A , Semen , John , Alex S
