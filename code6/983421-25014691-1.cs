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
     public class SearchResultViewModel
    {
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string County { get; set; }
        public List<string> Counties { get; set; }
        public bool AlterCriteria { get; set; }
        public List<Entity> SearchResultEntities { get; set; } 
    }
    public ActionResult SearchResult(SearchResultViewModel model)
        {
            ....
            // The search should use the search criteria that is stored in the session
            if (!model.AlterCriteria)
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
                var searchCriteria = new SearchCriteria(model.AccountId, model.AccountName, model.County);
                Session["searchCriteria"] = searchCriteria;
            }
            model.Counties = Database.GetCounties();
            model.SearchResultEntities = Database.GetEntities(query);
            return View(model);
        }
