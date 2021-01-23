    var productChildCounts = context.ProductGroups
                    .Include(pg => pg.Products)
                    .Include(pg => pg.Attributes)
                    .Select(pg => new
                    {
                        pg.Title,
                        ProductCount = pg.Products.Count(),
                        AttributeCount = pg.Attributes.Count()
                    });
