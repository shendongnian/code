    // The data structure that is stored to the session
    class SearchCriteria
    {
        public int? AccountId;
        public string AccountName;
        public string County;
        public SearchCriteria(int? accountId, string accountName, string county)
        {
            AccountId = accountId;
            AccountName = accountName;
            County = county;
        }
    }
    public ActionResult SearchResult(int? accountId, string accountName = "", string county = "", bool alterCriteria = false)
        {
            // The search should use the search criteria that is stored in the session
            if (!alterCriteria)
            {
                // Attempt to retrieve from session
                var searchCriteria = Session["searchCriteria"] as SearchCriteria;
                // Use previous search criteria if any
                if (searchCriteria != null)
                {
                    query.AccountId = searchCriteria.AccountId;
                    query.AccountName = searchCriteria.AccountName;
                    query.County = searchCriteria.County;
                }
            }
            // Provided input should be used as search criteria
            else
            {
                // Saved to session
                var searchCriteria = new SearchCriteria(accountId, accountName, county);
                Session["searchCriteria"] = searchCriteria;
            }
            ........
        }
