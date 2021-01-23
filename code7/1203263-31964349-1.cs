	var maxCategoryResult = list.AsParallel().Max(cat => 
	{
		SentenceSimilarity similarity = new SentenceSimilarity();
		string phrase = cat.Keywords.Replace("|", " ");
		float score = similarity.GetScore(
					phrase, string.IsNullOrEmpty(wholeWord) ? "" : wholeWord);
		
		CategoryResult catResult = null;
		if (catScore == 0 || catScore < score)
		{
			catResult = new CategoryResult
			{
				Category = cat,
				Score = score
			}
		}
		else
		{
			// Create different category?
		}
		
		return catResult;
	}
