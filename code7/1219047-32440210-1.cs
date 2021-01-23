	void AddCountries(string currentCountry, List<string> coutriesToAdd)
	{
		List<string> existingKey = null;
		if (!dictionary.TryGetValue(currentCountry, out existingKey))
		{
			// Create if not exists in dictionary
            existingKey = dictionary[currentCountry] = new List<string>()
		}
		existingKey.AddRange(coutriesToAdd);
	}
