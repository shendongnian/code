    var obectToTransfer = db.Customers.Where(c => c.Id == 5)
                                      .Select(c => new CustomerDTO
                                      {
                                         Id = c.Id
                                         ...
                                      }).FirstOrDefault();
