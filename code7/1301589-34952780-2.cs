    public static IOrderedQueryable<T> ApplySorts<T>(DataRequest request, IQueryable<T> items)
    {
        var sorts = request.Sort;
        var keyProperty = typeof(T).GetProperties().FirstOrDefault(prop => 
            prop.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false));
        if (sorts != null)
        {
            foreach (var sort in sorts)
            {
                items = items.OrderBy(sort.Field + " " + sort.Dir);
            }
        }
        else
        {
            items = items.OrderBy(keyProperty.Name); // set a default sort if there are no sorts provided
        }
            
        return (IOrderedQueryable<T>)items;
    }
