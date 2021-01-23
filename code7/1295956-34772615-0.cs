    var products = db.CategoryProduct.Include(c=>c.Product.ProductName)
                                     .Select(c=> new CategoryProductDTO()
                                                 {
                                                   //...
                                                   ProductNames= c.Product.ProductName.Where(a=>a.LanguageId==1)
                                                 })
                                     .ToList();
