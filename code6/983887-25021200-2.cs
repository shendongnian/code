    private IDictionary<string, ReftableCache> Lookup(List<string> list)
    {
        // execute the query
        var result = (from r in ReftableCached
                     where list.Contains(r.Description)
                     select new ReftableCache
                         {
                             RefTableName = r.RefTableName,
                             Reftable_K =  r.Reftable_K,
                             Description = r.Description
                         })
                     .ToList();
        // convert to dictionary 
        return result.ToDictionary(r => r.Reftable_K /*key*/
                                  , v => v /*value*/);
    }
