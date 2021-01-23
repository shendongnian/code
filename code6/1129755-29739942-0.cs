    var result = productList
        .GroupBy(p => p.Id)
        .Select(pg =>
            new
            {
                Id = pg.Key,
                CommonOtherList = pg
                    .SelectMany(solg => solg.t)
                    .GroupBy(solg => solg.value)
                    .Where(solg => solg.Count() == pg.Count())
                    .Select(solg => new { OtherId = solg.Key })
            });
    foreach (var product in result)
    {
        Console.WriteLine(product.Id);
        Console.WriteLine("**Common**");
        foreach (var otherProduct in product.CommonOtherList)
        {
            Console.WriteLine("-->{0}", otherProduct.OtherId);
        }
    }
