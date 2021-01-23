    var model = db.Categories
                  .Include(b => b.Books)
                  .Select(c => new Category
                               {
                                   Property1 = c.Property1,
                                   Property2 = c.Property2,
                                   ...,
                                   Books = c.Books.Take(4)
                               })
                  .ToList();
