    var anonymousProjection = dbContext.CustomerEntity
                                     .Where(c => ! c.IsDeleted)
                                     .Select(x=> new 
                                      {
                                           customers = x,
                                           orders = x.Orders.Where(h=>h.IsDeleted)
                                      }).ToList();
