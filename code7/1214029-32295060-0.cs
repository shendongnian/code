    public IQueryable<Item> GetItems<Item>(List<int> keys)
    {
        IQueryable<Item> itemsQuery = GetItemsQuery();
        return itemsQuery.Where(x => keys.Any(y => x.Key == y)).AsQueryable();
    }
