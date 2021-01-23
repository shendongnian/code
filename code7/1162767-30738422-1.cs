	public static TEnum GetRandomEnum<TEnum>(this Random rand, IEnumerable<TEnum> excludedValues)
	{
		var type = typeof(TEnum);
		if (!type.IsEnum)
			throw new ArgumentException("Not an enum type");
		
		
		var values = Enum.GetValues(type).Cast<TEnum>();
		
		if (excludedValues != null && excludedValues.Any())
			values = values.Except(excludedValues); 
        //if you call this a lot, you could consider saving this collection in memory
        //   and separate the logic to avoid having to re-generate the collection
        
		
		//create a random index for each possible Enum value 
		//will never be out of bounds because it NextDouble returns a value
		//between 0 (inclusive) and 1 (exclusive)  or [0, 1)
		int randomIndex = (int) (rand.NextDouble() * values.Count());
		return values.ElementAt(randomIndex);
	}	
