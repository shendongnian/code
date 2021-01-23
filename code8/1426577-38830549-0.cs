     OrderBy(c => c.RiceType).Select(c => new { RiceId = c.RiceId, 
                                                 RiceType = c.RiceType,
                                                 RicePrice = c.RicePrice,
                                                 DisplayValue = c.RiceType + ": " + c.RicePrice 
                                               })
