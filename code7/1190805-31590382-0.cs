          var customer = _db.Customers
                            .Where(c => c.Id== vm.Customer.Id)
				            .Include(c => c.Consultants)
                            .SingleOrDefault();
          customer.Consultants = _db.Consultants
                                    .Where(x => vm.SelectedConsultants.Contains(x.Id)).ToList();
          _db.SaveChanges();
