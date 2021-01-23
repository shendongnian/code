              // obtain a set of all { CategoryId, Seller } pairs
    var n = l.SelectMany(s => s.Products.Select(p => new {
                                                           Category = p.CategoryId, 
                                                           Seller = s
                                                         }))
              // group those by CategoryId
             .GroupBy(cp => cp.Category)
              // create a CategoryModel from each group
             .Select(g => new CategoryModel { 
                                              Id = g.Key, 
                                              Sellers = g.Select(cp => cp.Seller).ToList()
                                            })
              /make a list
             .ToList();
