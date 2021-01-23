    var products = (from p in db.Products
                   where p.CategoryId == category.Id
                   && p.Active && !p.Deleted
                   && p.ProductOptions.Any(po => po.Active && !po.Deleted)
                   select new ProductDTO
                    {
                       Id = p.Id,
                       Name = p.Name,
                       Description = p.Description,
                       ProductOptionDTOs = (from po in db.ProductOptions
                                            where po.ProductId == p.ProductId
                                            && po.Active
                                            && !po.Deleted
                                            select new ProductOptionDTO
                                            {
                                                Id = po.Id,
                                                Name = po.Name,
                                                Price = po.Price
                                            }).ToList() 
                    }).ToList()
