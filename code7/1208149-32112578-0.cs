    var aggregation = collection.Aggregate()
        .Unwind<Smartphone, UnwindedSmartphone>(x => x.Properties)
        .Group(key => key.Property, g => new
        {
            Count = g.Count(),
            Articles = g.Select(x => new AggregatedSmartphoneArticle
            {
                Name = x.Name,
                Description = x.Description,
                Type = x.Type
            }).Distinct()
        });
