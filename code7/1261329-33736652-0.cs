    var query = ctx.Employee
                   .Include(e => e.ContactAddresses)
                   .Include(e => e.Contracts)
                   .MyFilter();
    
    query.ToList().Select(e => 
    {
        ContactNames = e.ContactAddresses.Select(c => c.DisplayName),
        ContractNames = e.Contracts.Select(c => c.DisplayName)
    });
