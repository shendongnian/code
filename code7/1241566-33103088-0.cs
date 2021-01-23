    var query = DB_Context.Clients.AsQueryable();
    if (FromDate.HasValue) query = query.Where(...);
    if (ToDate.HasValue) query = query.Where(...);
    ...
    return query.OrderByDescending(k => k.Id).Take(1000).ToList();
