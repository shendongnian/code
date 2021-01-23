    var _dbContext = new MyDbContext();
    var company = _dbContext.Companies.Include("").SingleOrDefault(c => c.Id == companyId);
    var products = _dbContext.Companies.Include("").SingleOrDefault(c => c.Id == companyId)
                    ?.CompanyProducts
                    .Where(cp => cp.IsBuyable && cp.Product.IsPublished)
                    .OrderByDescending(c => c.Product.PublishDate)
                    .ThenBy(c => c.Product.Name)
                    .ToList();
    if(company != null)
    {
        company.CompanyProducts = products;
    }
    return company;
