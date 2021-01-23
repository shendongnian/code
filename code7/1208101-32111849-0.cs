    var aggregation = collection.Aggregate()
        .Unwind<Smartphone, UnwindedSmartphone>(x => x.Properties)
        .Group(key => key.Property, g => new
        {
            Id = g.Key,
            Count = g.Count(),
            Articles = g.Select(x => new
            {
                Name = x.Name
            }).Distinct()
        })
        .SortBy(x => x.Id);
