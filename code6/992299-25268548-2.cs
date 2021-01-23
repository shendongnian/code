    // Number of product SKUs
    int nProducts = products.Select(p => p.SKU).Distinct().Count();
    // Warehouses and their products
    Dictionary<int, List<Product>> warehouses = products
        .GroupBy(p => p.WarehouseID)
        .ToDictionary(g => g.Key, g => g.ToList());
    List<int> minWarehouseSet = warehouses
        // Get list of unique warehouse ids
        .Select(p => p.Key).ToList()
        // Get all combinations of warehouses
        .Combinations()
        // Order sets by the number of items
        .OrderBy(ws => ws.Count())
        // Find set which satisfies requirement (contains all products)
        .First(ws => ws.SelectMany(w => warehouses[w]).Distinct().Count() == nProducts)
        .ToList();
    foreach (var product in products.Where(p => minWarehouseSet.Contains(p.WarehouseID)))
        Console.WriteLine("{0}|{1}", product.SKU, product.WarehouseID);
