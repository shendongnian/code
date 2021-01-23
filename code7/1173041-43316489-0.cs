    var quoteDatePredicate= PredicateBuilder.New<SearchData>();
    
    if (searchCriteria.QuoteFromDate.HasValue)
    {
        quoteDatePredicate.And(x => x.QuoteDate >= searchCriteria.QuoteFromDate);
    }
    
    var saleDatePredicate = PredicateBuilder.New<SearchData>();
    
    if (searchCriteria.SaleDate.HasValue)
    {
        saleDatePredicate.And(x => x.SaleDate >= searchCriteria.SaleDateFrom);
    }  
