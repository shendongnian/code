    ctx.Employee.Include(e => e.ContactAddresses).MyFilter().ToList();
    ctx.Employee.Include(e => e.Contracts).MyFilter().ToList();
    
    
    var query = ctx.Employee
                   .MyFilter();
    
    query.ToList().Select(e => 
    {
        ContactNames = e.ContactAddresses.Select(c => c.DisplayName),
        ContractNames = e.Contracts.Select(c => c.DisplayName)
    });
