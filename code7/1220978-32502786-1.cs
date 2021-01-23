    public IQueryable<T> PerformSearch<T>(string searchPath)
        where T: SearchResultItem
    {
    
        var searchQuery = _SearchContext.GetQueryable<T>()
        .Where(i => i.Path.StartsWith(searchPath));
    
        return searchQuery;
    
    }
    
    public IQueryable<T> PerformSearch<T>(string searchPath, string templateName)
        where T: SearchResultItem
    {
        var searchQuery = PerformSearch<T>(searchPath).Where(x => x.TemplateName == templateName);
    
        return searchQuery;
    }
