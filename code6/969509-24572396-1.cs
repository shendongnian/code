    invoices
        .SelectMany(x => x.InvoiceDetails)
        .GroupBy(id => id.Invoice.MemberId)
        .Select(g => new {
                   MemberOrCustomer = g.Key,
                   Amount = g.Sum(x => x.Amount)
        });
 
