            var products = db.Products
                .AsNoTracking()
                .Where(p =>
                    p.CategoryId == category.Id
                    && p.Active && !p.Deleted
                    && p.ProductOptions.Any(po => po.Active && !po.Deleted))
                .Select(p =>
                    new
                    {
                        product = p,
                        //there is no need to filter, as it's filtered above
                        options = p.ProductOptions
                    }
                )
                .AsEnumerable()
                .Select(s =>
                    new ProductDTO
                    {
                        Id = s.product.Id,
                        Name = s.product.Name,
                        Description = s.product.Description,
                        ProductOptionDTOs = s.options
                            .Select(po =>
                                new ProductOptionDTO
                                {
                                    Id = po.Id,
                                    Name = po.Name,
                                    Price = po.Price
                                }
                            )
                    }
                );
