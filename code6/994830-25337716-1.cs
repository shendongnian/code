    public int GetCount(IQueryable<Parent> query)
    {
        return query.Count();
    }
    
    public IQueryable<Parent> GetQuery(string name, int? childId)
    {
         var query = context.Set<Parent>().AsQueryable();
    
         if (!string.IsNullOrEmpty(name))
         {
              query = query.Where(x => x.Name == name);
         }
    
         if (childId.HasValue)
         {
             query = query.Where(x => x.Children.Any(y => y.Id == childId.Value));
         }
    
         return query;
    }
    
    public IOrderedQueryable<Parent> GetOrderedQuery(IQueryable<Parent> query)
    {
          return query.OrderBy(x => x.Id);
    }
    
    public IEnumerable<Parent> GetPageData(IOrderedQueryable<Parent> query, int page, int pageSize)
    {
          return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
    public void Example()
    {
         // filter
         var query = GetQuery("Test", 4);
         
         // total count on filtered query
         var count = GetCount(query);
    
         // order
         var orderedQuery = GetOrderedQuery(query);
    
         // paginate and execute query
         var pagedData = GetPageData(orderedQuery, page: 1, pageSize: 2);
     }
