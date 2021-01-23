    var tasks = items.Select(
        async item => new
        {
            Item = item,
            IsValid = await IsValid(item)
        });
    var tuples = await Task.WhenAll(tasks);
    var validItems = tuples
        .Where(p => p.IsValid)
        .Select(p => p.Item)
        .ToList();
