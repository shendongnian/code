	public void MinMaxAge()
	{
		// Have to convert to list or array in order to get min/max
		var ageRange = myDictionary.ToList();
		// Created easier to read Keys and Values       
		var minAge = ageRange.Min(myDictionary => myDictionary.Value);
		var minNames = myDictionary.Where(x => x.Value == minAge)
			.Select(x => x.Key)
			.Aggregate((current, next) => current + ", " + next);
		var maxAge = ageRange.Max(myDictionary => myDictionary.Value);
		var maxNames = myDictionary.Where(x => x.Value == maxAge)
			.Select(x => x.Key)
			.Aggregate((current, next) => current + ", " + next);
		Console.WriteLine("The youngest age is {0} and that is {1}.", minAge, minNames);
		Console.WriteLine("The youngest age is {0} and that is {1}.", maxAge, maxNames);
	}
