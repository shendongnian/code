    dbContext.Quote.Add(quote);
    foreach (var service in Quote.Services)
    {   
        quote.services .Add(service);
        dbContext.Services.Add(service);
    }
    dbContext.SaveChanges();
