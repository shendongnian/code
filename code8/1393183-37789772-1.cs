	public void SearchWordSynonymsByLevenstein()
	{
		var words = wordCounter.Keys.ToList();
		
		for(int i = 0; i < words.Count - 1; i++)
		for(int j = i +1; j < words.Count; j++)
		{
			var eachWord = words[i];
			var eachSecondWord  = words[j];
			if (eachWord.Length <= 3 
				|| Math.Abs(eachWord.Length - eachSecondWord.Length) >= 2)
			{
				continue;
			}
			
			var score = LevenshteinDistance.Compute(eachWord, eachSecondWord);
			if (score >= 2)
			{
				continue;
			}
			
			if(!wordSynonymsByLevenstein.Any(x => x.Value.ContainsKey(eachSecondWord)))
			{
				if (!wordSynonymsByLevenstein.ContainsKey(eachWord))
				{
					wordSynonymsByLevenstein.Add(eachWord, new Dictionary<string, int> { { eachSecondWord, wordCounter[eachSecondWord] } });
				}
				else
				{
					wordSynonymsByLevenstein[eachWord].Add(eachSecondWord, wordCounter[eachSecondWord]);
				}
			}
		}
	}
