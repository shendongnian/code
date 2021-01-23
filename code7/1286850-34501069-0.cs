    from t in Transactions
    join p in Products on t.Product.ID equals p.ID
    where t.TransactionDate >= DateTime.Parse("12/01/2015") && t.TransactionDate <= DateTime.Parse("12/31/2015")
    group t.TransactionType.AddRemove == "Addition" 
               ? t.FullQuantity + (t.PartialQuantity / p.Pieces) 
               : -1 * (t.FullQuantity + (t.PartialQuantity / p.Pieces)) 
        by new {p.ProductCode, p.Description} into g
    select new 
    {
        Product = g.Key.ProductCode,
        Description = g.Key.Description,
        TotalQuantityChanged = g.Sum().ToString()
    }
