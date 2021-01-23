    var res = Context.Categories
                  .Select(u => new {
                      Category = u,
                      Product = u.Products.OrderByDescending(m => m.Id).First()
                  })
                  .AsEnumerable()
                  .Select(a => a.Category);
