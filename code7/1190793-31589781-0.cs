    Results = Result.GroupBy(x => new { x.TrdID, x.Date, x.Price })
        .Where(g => g.Count() == 2)
        .Select(g => new object 
        {
              TrdID  = g.Key.TrdID,
              Date   = g.Key.Date,     
              Price  = g.Key.Price,
              Seller = g.First(x => x.Seller != null).Seller,
              Buyer  = g.First(x => x.Buyer  != null).Buyer 
        })
        .ToList();
