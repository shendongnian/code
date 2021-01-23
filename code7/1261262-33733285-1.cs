    foreach(IGrouping<enumType, Item> group in lp)
    {
        Task<ProcessedItem> t = Task.Run(() => ProcessItems(group.ToList(), group.Key));
    
        tasks.Add(t);
    }
    
    await Task.WhenAll(tasks);
    
    (...)
