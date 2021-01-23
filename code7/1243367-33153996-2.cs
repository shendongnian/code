    // this is IQueryable 
    var stocksQuery = context.Stocks;
    
    if (!string.IsNullOrWhiteSpace(batch)) 
    {
        // adding some filters for IQueryable
        stocksQuery = stocksQuery.Where(stock => stock.BatchNo == batch);
    }
    
    // add more conditions ...
    
    // the actual query will be executed here:
    var result = stocksQuery.ToList();
