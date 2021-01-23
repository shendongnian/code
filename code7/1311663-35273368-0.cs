    var query= await _unit.Repository<AspNetUser>()
                          .Queryable()
                          .Where(u=>!u.Cars.Any(c=>c.Id==carId))
                          .Select(c => new CustomerModel()
                                        {
                                            Id = c.Id,
                                            Email = c.Email
                                        })
                          .ToListAsync();
