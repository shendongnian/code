	void AddCountries(string currentCountry, List<string> coutriesToAdd)
	{
		List<string> existingCountry = null;
		if (!dictionary.TryGetValue(currentCountry, out existingCountry))
		{
			// Create if not exists in dictionary
			dictionary[currentCountry] = new List<string>();
            existingCountry = dictionary[currentCountry];
		}
		existingCountry.AddRange(coutriesToAdd);
	}
