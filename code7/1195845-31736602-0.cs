    static IEnumerable<T> RetreivePages<T, U>(
        IQueryable<T> query, 
        Func<T, U> orderBy, 
        int count, int pageSize)
    {
        var orderedQuery = query.OrderBy(orderBy);
        int pages = count / pageSize;
        if (count % pageSize > 0)
        {
            pages++;
        }
        for (int i = 0; i < pages; i++)
        {
            foreach (T item in orderedQuery.Skip(i * pageSize).Take(pageSize))
            {
                yield return item;
            }
        }
    } 
