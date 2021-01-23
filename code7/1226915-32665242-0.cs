    var result = entity.Categories.Select
                             (
                                cats => new
                                    {   
                                        cats.CategoryName,
                                        cats.Description,
                                        Products = cats.Products.Take(3)
                                    }
                             ).Take(5);
