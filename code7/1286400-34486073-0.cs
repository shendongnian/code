    var dailyList = await db.ShoppingData.Where(c=>StoreId == id)
        .GroupBy(c=> SqlFunctions.DatePart("dw",c.ShoppindDate))
        .Select(o=> new ShowShoppingDailyVM
                      {
                          Day = o.Key,
                          Turnover = o.DefaultIfEmpty().Sum(a=>a.InvoiceAmount),
                          Avg = o.DefaultIfEmpty().Sum(a=>a.InvoiceAmount)
                                   /o.Select(d => d.ShoppindDate).Distinct().Count()
                          Count = o.Count()
                      })
        .ToListAsync();
