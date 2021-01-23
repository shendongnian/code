	public void SearchWordSynonymsByLevenstein()
	{
		var used = new HashSet<string>();
		foreach (var eachWord in wordCounter)
		{
			foreach (var eachSecondWord in wordCounter)
			{
				if (eachWord.Key == eachSecondWord.Key 
					|| eachWord.Key.Length <= 3 
					|| Math.Abs(eachWord.Key.Length - eachSecondWord.Key.Length) >= 2)
				{
					continue;
				}
				var score = LevenshteinDistance.Compute(eachWord.Key, eachSecondWord.Key);
				if (score >= 2)
				{
					continue;
				}
				
				if(used.Add(eachSecondWord.Key)))
				{
					if (!wordSynonymsByLevenstein.ContainsKey(eachWord.Key))
					{
						wordSynonymsByLevenstein.Add(eachWord.Key, new Dictionary<string, int> { { eachSecondWord.Key, eachSecondWord.Value } });
					}
					else
					{
						wordSynonymsByLevenstein[eachWord.Key].Add(eachSecondWord.Key, eachSecondWord.Value);
					}
				}
				
			}
		}
	}
