    [HttpGet]
    public dynamic Get()
    {
        var dbContext = new ApplicationContext();
        var result = dbContext.Companies
            .Select(e => new { e.CompanyName, e.Id, e.Employees, e.Admins })
            .ToList();
        return result;
    }
