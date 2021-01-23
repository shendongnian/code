    public List<SimpleItem> GetAllItemsFromQuery<T>( T table,Int32 skip)
        where T: IEnumerable<IEntity>
    {
        List<SimpleItem> SimpleItemList = new List<SimpleItem>();
        SimpleItemList = table.Where(p => p.IsActive == true).OrderBy(p => p.Name).Select(p => new SimpleItem { id = p.Id, Name = p.Name, IsActive = p.IsActive }).Skip(skip).Take(30).Distinct().ToList();
        return SimpleItemList;
    }
