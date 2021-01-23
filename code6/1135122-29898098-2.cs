    public List<CustomerDto> Fetch()
    {
        using(var ctx = DbContextManager<CustomerContext>.GetManager("CustomerDB"))
        {
            var result = (from r in ctx.DbContext.Customers 
                         select new 
                         {
                             CustomerId = r.CustomerId,
                             Name = r.Name,
                             Email = r.Email
                         }).ToList().Select(x => new CustomerDto{ CustomerId = x.CustomerId, Name = x.Name, Email = x.Email });
            return result.ToList();
        }
    }
