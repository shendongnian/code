    var customerVm= _db.Customers
                       .Select(c => new CustomerVM
                                    {
                                      Name = c.Name,
                                      Products = c.Products.
                                                      Select(s => 
                                        new ProductVM {ProductName= s.ProductName}).ToList()
                                    });
