    public static System.Linq.IQueryable<TRecord> Sort<TRecord, TKey>(this System.Linq.IQueryable<TRecord> aQuery, 
      System.Linq.Expressions.Expression<System.Func<TRecord, TKey>> aSortFieldSelector, SortOrder aSortOrder, bool aIsPrimarySort)
    {
      System.Linq.IOrderedQueryable<TRecord> lOrderedQuery = aIsPrimarySort ? null : aQuery as System.Linq.IOrderedQueryable<TRecord>;
      // *1
      if (aSortOrder == SortOrder.Descending)
      {
        if (lOrderedQuery == null)
          lOrderedQuery = aQuery.OrderByDescending(aSortFieldSelector);
        else
          lOrderedQuery = lOrderedQuery.ThenByDescending(aSortFieldSelector);
      }
      else
      {
        if (lOrderedQuery == null)
          lOrderedQuery = aQuery.OrderBy(aSortFieldSelector);
        else
          lOrderedQuery = lOrderedQuery.ThenBy(aSortFieldSelector);
      }
      if (lOrderedQuery != null)
        return lOrderedQuery.AsQueryable();
      else
        return aQuery;
    }    
