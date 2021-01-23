    // Keyword filter
    if (string.IsNullOrWhiteSpace(request.Keyword)) 
    {
        return emptyList;
    }
    var searchResults = _items.Where(x => x.Name.Contains(request.Keyword)).ToList();
    if (searchResults.Any())
    {
        return searchResults;
    }
    searchResults = _items.Where(x => x.Number == request.Keyword).ToList();
    if (searchResults.Any())
    {
        return searchResults;
    }
    searchResults = _items.Where(x => x.Code == request.Keyword).ToList();
    if (searchResults.Any())
    {
        return searchResults;
    }
    return emptyList;
