    var recentchats = MessagesCollection.AsQueryable()
        .Where(x => x.CA == 1 || x.CB == 1)
        .GroupBy(x => new MultiFieldIgnoreOrderComparer(new[] { x.CA, x.CB }))
        .Select(g => g.First())
        .ToList();
