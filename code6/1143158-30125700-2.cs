    results = results
        .GroupBy(p => new { p.ProductCode, p.Name, p.Type })
        .Select(g => new Product {
            ProductCode = g.Key.ProductCode,
            Name = g.Key.Name,
            Type = g.Key.Type,
            Price = g.Sum(p => p.Price)
        })
        .ToList();
