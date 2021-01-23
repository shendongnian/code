    // Keyword filter
    var keyword = request.Keyword;
    if (!string.IsNullOrWhiteSpace(keyword))
    {    
        var searchResults = _items.Where(x => x.Name.Contains(keyword)).ToList();
        if (searchResults.Length == 0)
        	searchResults = _items.Where(x => x.Number == keyword).ToList();
    	if (searchResults.Length == 0)
    		searchResults = _items.Where(x => x.Code == keyword).ToList();		
    	if (searchResults.Length == 0)
    		_items.Clear();
    	else
    		_items = searchResults;
    }
