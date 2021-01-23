    var productList = products.GroupBy(p => p.Category)
        .Select(g => new { Key = g.Key, Elements = g.ToList() })
        .ToList();
    Console.WriteLine(productList.Count);
    Console.WriteLine(productList[2].Elements.Count);
    Console.WriteLine(productList[1].Elements[3]);
