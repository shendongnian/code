    int nProducts = products.Select(p => p.SKU).Distinct().Count();
    Dictionary<int, List<Product>> warehouses = products
        .GroupBy(p => p.WarehouseID)
        .ToDictionary(g => g.Key, g => g.ToList());
    List<int> minWarehouseSet = warehouses
        .Select(p => p.Key).ToList()
        .Combinations()
        .OrderBy(ws => ws.Count())
        .First(ws => ws.SelectMany(w => warehouses[w]).Distinct().Count() == nProducts)
        .ToList();
    foreach (var product in products.Where(p => minWarehouseSet.Contains(p.WarehouseID)))
        Console.WriteLine("{0}|{1}", product.SKU, product.WarehouseID);
