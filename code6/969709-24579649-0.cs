    private static string GetArticleIdFiltered(string filtered)
    {
    	var uri = new Uri(filtered);
    	return Path.GetFileNameWithoutExtension(uri.LocalPath);
    }
    
    private static string GetArticleIdLocked(string locked)
    {
    	var uri = new Uri(locked);
    	var queryParams = HttpUtility.ParseQueryString(uri.Query);
    	return queryParams["om"];
    }
    
    for (int x = 0; x < lockedLinks.Count; x++)
    {
    	var lockedArticle = GetArticleIdLocked(lockedLinks[x]);
    	var filteredId = GetArticleIdFiltered(ExtractLinks.FilteredLinks[i]);
    	if (lockedArticle == filteredId)
    	{
    		string h = "found";
    	}
    }
