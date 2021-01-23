    IEnumerable<FactoryOrder> orders =
        new[]
        {
            new FactoryOrder(20, "Apple"),
            new FactoryOrder(21, "Orange"),
            new FactoryOrder(22, "Pear"),
            new FactoryOrder(42, "WaterMelon"),
            new FactoryOrder(51, "JackFruit"),
            new FactoryOrder(71, "Grapes"),
            new FactoryOrder(72, "Mango"),
            new FactoryOrder(73, "Cherry"),
        };
    var result = orders.OrderBy(t => t.Id).Aggregate(new Dictionary<int, List<FactoryOrder>>(),
        (dir, curr) =>
        {
            var prevId = dir.SelectMany(d => d.Value.Select(v => v.Id))
                .OrderBy(i => i).DefaultIfEmpty(-1)
                .LastOrDefault();
            var newKey = dir.Select(d => d.Key).OrderBy(i => i).LastOrDefault();
            if (prevId == -1 || curr.Id - prevId > 1)
            {
                newKey = curr.Id;
            }
            if (!dir.ContainsKey(newKey))
            {
                dir[newKey] = new List<FactoryOrder>();
            }
            dir[newKey].Add(curr);
            return dir;
        }, c => c)
        .Select(t => new
                     {
                         t.Key, 
                         Items = string.Join(" ", t.Value.Select(v => v.Name))
                     }).ToList();
