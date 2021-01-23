    var res = Context.Categories
                  .Select(u => new {
                      Category = u,
                      Product = u.Products.OrgerByDescending(o => o.Id).First()
                  })
                  .AsEnumerable()
                  .Select(a => a.Category);
