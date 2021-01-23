    select new {
        ProductPeriod = p,  
        Price = p.Prices.GroupBy(x => x.FirmID)
            .OrderByDescending(x =>x.Created).ThenByDescending(x=>x.ProductPrice).FirstOrDefault()
    }
  
