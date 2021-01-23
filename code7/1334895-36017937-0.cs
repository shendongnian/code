    IQueryable<Company> query = db.Companies;
    if (!String.IsNullOrEmpty(name))
        query = query.Where(c => c.Name.Contains(name));
    if (!String.IsNullOrEmpty(email))
        query = query.Where(c => c.Email.Contains(email));
    if (isSupplier.HasValue)
        query = query.Where(c => c.isSupplier.Equals(isSupplier));
    if (isCustomer.HasValue)
        query = query.Where(c => c.isCustomer.Equals(isCustomer));
