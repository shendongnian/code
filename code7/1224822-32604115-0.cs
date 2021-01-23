    var prices = (from p in context.Products
                 join pr in context.Prices.Include("Prices.OldPrices") on p.ProductId equals pr.ProductId
                 join oldPr in context.OldPrices on pr.PriceId equals oldPr.PriceId
                 where p.ProductId > productId && pr.Enabled
                 && oldPr.LastUpdate >= date
                 select pr).ToList(); // here you'll have prices with old prices  
  
    return new Product() { Prices = prices };
