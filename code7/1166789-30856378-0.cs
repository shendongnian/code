    context
      .Orders  
      .Select(o => new { CustomerId = o.CustomerId, Value = o.Products.Sum(p => p.Quantity * p.Product.Price) }) 
      .GroupBy(o => x.CustomerId)
      .Select(o => new { CustomerId = o.CustomerId, MaxValue = o.Select(a => a.Value).Max() })
      .OrderByDescending(x => x.MaxValue)
      .Select(x => x.CustomerId)
      .Take(5)
      .ToArray()
      ;
