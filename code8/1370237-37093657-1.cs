    context.Item1s.Select(item1 => new
    {
        Item1 = item1,
        Item2s = item1.Item2List.Select(item2 => new
        {
            Item2 = item2,
            Item3Count = item2.Item3List.Count()
        })
    })
