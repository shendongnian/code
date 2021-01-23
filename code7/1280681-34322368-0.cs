    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Linq;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.Data.Items;
    List<Item> ResultsItems = new List<Item>();
    SitecoreIndexableItem bucket = Context.Database.GetItem(Constants.BucketIds.NEWS);
    using (var searchcontext = ContentSearchManager.GetIndex(bucket).CreateSearchContext())
    {
        IQueryable<SearchResultItem> searchQuery =
            searchcontext.GetQueryable<SearchResultItem>()
                                            .OrderByDescending(x => x.CreatedDate)
                                            .Take(10);
        SearchResults<SearchResultItem> results = searchQuery.GetResults();
        // fetch the Sitecore Items if you do not want to work with the SearchResultItem
        foreach (var hit in results.Hits)
        {
            Item item = hit.Document.GetItem();
            if (item != null)
            {
                ResultsItems.Add(item);
            }
        }
    }
