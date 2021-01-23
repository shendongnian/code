	void AddCountries(string languageKey, List<string> coutriesToAdd)
	{
		List<string> existingKey = null;
		if (!dictionary.TryGetValue(languageKey, out existingKey))
		{
			// Create if not exists in dictionary
            existingKey = dictionary[languageKey] = new List<string>()
		}
		existingKey.AddRange(coutriesToAdd);
	}
