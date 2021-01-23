            var index = SearchIndexInfoProvider.GetSearchIndexInfo("indexName");
            if (index != null)
            {
                SearchParameters parameters = new SearchParameters()
                {
                    
                    SearchFor = "Something",
                    SearchSort = "##SCORE##",
                    Path = "/%",
                    ClassNames = "",
                    CurrentCulture = "EN-US",
                    DefaultCulture = CultureHelper.EnglishCulture.IetfLanguageTag,
                    CombineWithDefaultCulture = false,
                    CheckPermissions = false,
                    SearchInAttachments = false,
                    User = (UserInfo)MembershipContext.AuthenticatedUser,
                    SearchIndexes = index.IndexName,
                    StartingPosition = 0,
                    DisplayResults = 100,
                    NumberOfProcessedResults = 100,
                    NumberOfResults = 0,
                    AttachmentWhere = String.Empty,
                    AttachmentOrderBy = String.Empty,
                };
                // Performs the search and saves the results into a DataSet
                System.Data.DataSet results = SearchHelper.Search(parameters);
                if (!DataHelper.DataSourceIsEmpty(results))
                {
                    foreach (DataRow searchItem in results.Tables[0].Rows)
                    {
                        // do whatever you need with the search item
                    }
                }
            }
