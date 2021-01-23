    //...  
    group new { company, invoice } by new
    {
        invoice.InvoiceNo,
        invoice.InvoiceDate,
        invoice.InvoiceId,
        invoice.InvoiceType,
        company.CompanyId,
        company.CompanyName,
    } into g
    select new
    {
       g.Key.CompanyId,
       g.Key.CompanyName,
       g.Key.InvoiceNo,
       g.Key.InvoiceType,
       g.Key.InvoiceId,
       Sum = g.Sum(o => o.invoice.Quantity * o.company.Rate)
    };
