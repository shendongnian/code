        //Fetching what eva searchterm some bloke is throwin' our way
        string q = Request.QueryString["search"].Trim();
        //Fetching our SearchProvider by giving it the name of our searchprovider
        Examine.Providers.BaseSearchProvider Searcher = Examine.ExamineManager.Instance.SearchProviderCollection["SiteSearchSearcher"];
        
        // control what fields are used for searching and the relevance
        var searchCriteria = Searcher.CreateSearchCriteria(Examine.SearchCriteria.BooleanOperation.Or);
        var query = searchCriteria.GroupedOr(new string[] { "nodeName", "introductionTitle", "paragraphOne", "leftContent", "..."}, q.Fuzzy()).Compile();        
        //Searching and ordering the result by score, and we only want to get the results that has a minimum of 0.05(scale is up to 1.)
        IEnumerable<SearchResult> searchResults = Searcher.Search(query).OrderByDescending(x => x.Score).TakeWhile(x => x.Score > 0.05f);  
        //Printing the results
        foreach (SearchResult item in searchResults)
        {
            //get the parent node
            IPublishedContent node = new UmbracoHelper(UmbracoContext.Current).TypedContent(item.Fields["id"].ToString());
            IPublishedContent parentNode = node.Parent;
            //if you wish to check for a particular document type you can include this
            if (item.Fields["nodeTypeAlias"] == "SubPage")
            {
            }
        }
