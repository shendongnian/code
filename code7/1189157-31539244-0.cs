    List<Payment> distinct = invoices
       .GroupBy(c => c.CustomerId)
       .Select(c => new Payment
       {
         CustomerId = c.Key, 
         Total = c.Sum(x => x.Amount)
       }).ToList();
