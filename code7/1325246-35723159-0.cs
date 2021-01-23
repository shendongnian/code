    var result = queryResult.OrderBy(c => c.TariffName)
                        .Take(count)
                        
                        .Select(c => new
                            {
                                Text = c.TariffName,
                                Key = c.TariffId,
                                Price = c.LineRental
                            });
    var list = result.ToList().Select(c=>new {
              Text = string.Format("{0} - {1}", c.Text, c.Price),
              Key=Key,
              Price=Price
    });
