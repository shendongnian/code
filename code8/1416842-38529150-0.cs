    Categories
        .Where(c => c.ID == 18)
        .Include("Products.ProductPrices")
        .Select(c => new
                    {
                        ID = c.ID,
                        Name = c.Name, // other properties
                        Products = c.Products
                                    .Select(p => new
                                    {
                                        Product = p,
                                        // Or maybe various Product properties
                                        ProductPrices = p.ProductPrice
                                    })
                    })
