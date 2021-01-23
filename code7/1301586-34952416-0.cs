    public static IOrderedQueryable<T> ApplySorts<T>(DataRequest request, IQueryable<T> items)
    {
        var sorts = request.Sort;
        if (sorts != null)
        {
            foreach (var sort in sorts)
            {
                items = items.OrderBy(sort.Field + " " + sort.Dir);
            }
        }
        else
        {
            items = items.OrderBy(i => 1); // set a default sort if there are no sorts provided
        }
            
        return (IOrderedQueryable<T>)items;
    }
