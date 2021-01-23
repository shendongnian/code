    (from r in Results
    group r by TrdID into g
    where g.Count() == 2
    let g1 = g.First()
    let g2 = g.Last()
    select new {
        TrdId = g.Key,
        Date = g1.Date,
        Price = g1.Price,
        Seller = g1.Seller ?? g2.Seller,
        Buyer = g1.Buyer ?? g2.Buyer
    })
