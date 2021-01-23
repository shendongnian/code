    IQueryable<Request> SearchRequests (string searchTerm, string specField, string searchType)
    {
        var predicate = PredicateBuilder.False<Request>();
    
        //These two are not correct and I need help writing these
        if (searchType == "Fuzzy" && searchTerm != "" && specField != "None")
        {
            predicate = predicate.Or (r => r.(specField).Contains(searchTerm));
        }
        if (searchType == "Literal" && searchTerm != "" && specField == "None")
        {
            predicate = predicate.Or (r => r.Equals(searchTerm));
        }
        
        return new IntegrationDBEntities()
                      .Requests
                      .AsExpandable()
                      .Where(predicate);
    }
