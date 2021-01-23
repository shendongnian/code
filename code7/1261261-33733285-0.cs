    foreach(IGrouping<enumType, Item> group in lp)
    {
        Task<ProcessedItem> t = new Task<ProcessedItem>(() => ProcessItems(group.ToList(), group.Key));
        t.Start();
        tasks.Add(t);
    }
    
    await Task.WhenAll(tasks);
    
    (...)
