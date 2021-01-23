    results = results
        .GroupBy(p => p.ProductCode)
        .Select(g => new Product {
            ProductCode = g.Key,
            Name = g.First().Name,
            Type = g.First().Type,
            Price = g.Sum(p => p.Price)
        })
        .ToList();
