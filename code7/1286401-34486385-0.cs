         var dailyList = await db.ShoppingData.Where(c=>StoreId == id)
        .Groupby(c=> SqlFunctions.DatePart("dw",c.ShoppindDate))
        .Select(o=> new ShowShoppingDailyVM{
            Day = o.Key,
            Turnover = o.DefaultIfEmpty().Sum(a=>a.InvoiceAmount),//Total Turnover
            //Avg= o.DefaultIfEmpty().Sum(a=>a.InvoiceAmount) / (What??) //Avg turnover
           Avg = o.DefaultIfEmpty().Sum(a=>a.InvoiceAmount) / (decimal) o.GroupBy(a=>
           SqlFunctions.DatePart("week",c.ShoppindDate)).Count(),
            Count = o.Count()
            }).ToListAsync();
