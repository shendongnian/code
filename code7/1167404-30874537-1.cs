    // base query
    var query = _dbContext.SomeItems.AsQueryable();
    
    var orderedQuery = query.OrderBy(t => t.SomeProperyToOrderBy);
    
    // pages the results
    // the WithPaging extension method requires an IOrderedQueryable
    // (orderedQuery) which is produced by calling OrderBy on an IQueryable<T>
    var withPaging = orderedQuery.WithPaging(yourDesiredPage, yourDesiredPageSize);
