    context.Item1s.Select(item1 => new Item1
    {
        Id = item1.Id,
        Item2s = item1.Item2List.Select(item2 => new Item2List
        {
            Id = item2.Id,
            Item3Count = item2.Item3List.Count()
        })
    })
