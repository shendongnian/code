    var invoices = ctx.Invoices.AsQueryable();
    
    if (inputInvoiceId > 0)
        invoices = invoices.Where(x => x.id == inputInvoiceId);
    
    if (!string.IsNullOrEmpty(inputCheckNumber))
        invoices = invoices.Where(x => x.checkNumber == inputCheckNumber);
    
    if (!string.IsNullOrEmpty(inputState))
        invoices = invoices.Where(x => x.state == inputState);
    return invoices.ToList();
