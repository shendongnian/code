    private bool SearchText()
    {
        // Get the search index
        SearchIndexInfo index = SearchIndexInfoProvider.GetSearchIndexInfo("MyNewIndex");
    
        if (index != null)
        {
            // Prepare parameters
            SearchParameters parameters = new SearchParameters()
            {
                SearchFor = "home",
                SearchSort = SearchHelper.GetSort("##SCORE##"),
                Path = "/%",
                ClassNames = "",
                CurrentCulture = "EN-US",
                DefaultCulture = CultureHelper.DefaultCulture.IetfLanguageTag,
                CombineWithDefaultCulture = false,
                CheckPermissions = false,
                SearchInAttachments = false,
                User = (UserInfo)CMSContext.CurrentUser,
                SearchIndexes = index.IndexName,
                StartingPosition = 0,
                DisplayResults = 100,
                NumberOfProcessedResults = 100,
                NumberOfResults = 0,
                AttachmentWhere = String.Empty,
                AttachmentOrderBy = String.Empty,
            };
    
            // Search
            DataSet results = SearchHelper.Search(parameters);
    
            // If found at least one item
            if (parameters.NumberOfResults > 0)
            {
                return true;
            }
        }
    
        return false;
    }
