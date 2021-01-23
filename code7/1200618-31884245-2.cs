    using (DailyContext context= DailyContext.Create())
    {
        //cleaning old prices
        foreach (var price in context.Prices)
        {
            context.DeleteObject(price);
        }
        context.SaveChanges();
    
        //Reseed the identity to 0.
        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (Prices, RESEED, 0)");
        //Roll the identity forward till it finds the last used number.
        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (Prices, RESEED)");
    
        for (int i = 0; i < newElements.Total; i++)
        {
            var newPrice = new Price()
            {
    
                Date = newElements.From.AddDays(i),
                PriceFrom = newElements.Price,
                TotalNights = newElements.TotalNights,
                Profit = newElements.Profit
            };
            context.AddToPrices(newPrice);
        }
    
        context.SaveChanges();
    }
