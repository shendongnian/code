    var res = Context.Categories
                  .Select(u => new {
                      Category = u,
                      Product = u.Products.OrderByDescending(m => m.Id).FirstOrDefault()
                  })
                  .AsEnumerable()
                  .Select(a => a.Category);
