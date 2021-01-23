    private  DataSet SearchText(string searchQuery){
        // Get the search index
        SearchIndexInfo index = SearchIndexInfoProvider.GetSearchIndexInfo(searchIndex);
        DataSet results = new DataSet();
        
        if (index != null)
        {
            // Prepare parameters
            SearchParameters parameters = new SearchParameters()
            {
                SearchFor = searchQuery,
                Path = "/%",
                ClassNames = "",
                CurrentCulture = "EN-US",
                DefaultCulture = CultureHelper.DefaultUICulture.IetfLanguageTag,
                CombineWithDefaultCulture = false,
                CheckPermissions = false,
                SearchInAttachments = false,
                User = (UserInfo) CMS.Membership.MembershipContext.AuthenticatedUser,
                SearchIndexes = index.IndexName,
                StartingPosition = 0,
                DisplayResults = 5000,
                NumberOfProcessedResults = 5000,
                NumberOfResults = 5000,
                AttachmentWhere = String.Empty,
                AttachmentOrderBy = String.Empty,
            };
        
            // Search returns resultset.
            results = SearchHelper.Search(parameters);
        }
        return results;
    }
