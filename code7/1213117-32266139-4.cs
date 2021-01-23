    static void PrintCollection<T, TKey, TOrder>(IRepository<T, TKey> repo, 
           Func<T,TOrder> orderBy)
    {
        var items = repo.GetItems();
        if (orderBy != null)
            items = items.OrderBy(orderBy);
        foreach (T p in items)
            Console.WriteLine(Convert.ToString(p));
    }
