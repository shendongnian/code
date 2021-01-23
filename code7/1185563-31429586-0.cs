    List<Item> third = first.Concat(second)
        .GroupBy(i => i.Name, StringComparer.InvariantCultureIgnoreCase)
        .Select(g => new Item
        {
            Name = g.Key,
            IsFound = g.Skip(1).Any()
        })
        .ToList();
