    List<Products> result = new List<Products>();
    foreach (var item in query.OrderByDescending(r => r.DistinctCount)) //warehouse with most products
    {
        if (!result.Any(r => item.DistinctProducts.Any(t => t == r.SKU)))
        {
            result.AddRange(item.DistinctProducts.Select(r => new Products { SKU = r, WarehouseID = item.WarehouseID }));
        }
    }
