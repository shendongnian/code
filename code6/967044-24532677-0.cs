     var fb = new Business();
     //fb.Id exists and is an int but it is auto incr in the db
     fb.Name = ub.ACCOUNT_NAME;
     fb.ServiceManager = ub.SERVICE_MANAGER;
     fb.AccountManager = ub.ACCOUNT_MANAGER;
     fb.SalesPerson = ub.SALESPERSON;
     fb.Created = DateTime.UtcNow;
     fb.Updated = DateTime.UtcNow;
     _context.Business.Add(fb);
     _context.SaveChanges();
