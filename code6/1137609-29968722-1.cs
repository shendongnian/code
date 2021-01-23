    var index = ContentSearchManager.GetIndex("sitecore_web_index");
    using (var context = index.CreateSearchContext()) {
        IQueryable<SearchResultItem> queryCalls = context.GetQueryable<SearchResultItem>().Where(item =>
                 item.TemplateName == callTemplateName &&
                 item.Path.StartsWith(callStartingPath) && 
                 item.Language == Sitecore.Context.Language.Name &&
                 item["appliedthemes"].Contains(themeID))
    }
    
