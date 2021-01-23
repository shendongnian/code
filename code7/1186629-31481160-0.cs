    var query = context.GetQueryable<Sitecore.ContentSearch.SearchTypes.SearchResultItem>();
    var folderFilter = PredicateBuilder.True<SearchResultItem>().And(i => !i.TemplateName.Contains("folder") && !i["_fullpath"].Contains("/testing"));
    var pathFilter = PredicateBuilder.True<SearchResultItem>();
    pathFilter = pathFilter.Or(i => i.Paths.Contains(Path1) || i.Paths.Contains(Path2));
        
    folderFilter = folderFilter.And(pathFilter);
