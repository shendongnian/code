    var company = DbContext.Companies.AsNoTracking()
                           .Include(c => c.Locations
                               .Select(l => l.Stores
                                   .Select(s => s.Products)))
                           .Where(c => c.Id == 123)
                           .FirstOrDefault();
    DbContext.Companies.Add(company);
    DbContext.SaveChanges();
