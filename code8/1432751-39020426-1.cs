    var query=db.SA_Items;
    if(includedTables!=null)
       query = includedTables.Aggregate(query, (current, include) => current.Include(include));
    query=query.Where(x => x.LastUpdated > lastUpdated)
               .Where(x => x.Active == true)
               .OrderBy(x => x.ItemID)
               .Skip(offset)
               .Take(limit);
    return query.ToList();// Materialize your query
