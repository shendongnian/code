	var invs = new List<Invoice> { new Invoice { InvoiceNumber = 1 }, 
                                   new Invoice { InvoiceNumber = 1 }, 
                                   new Invoice { InvoiceNumber = 1 },
                                   new Invoice { InvoiceNumber = 2 }, 
                                   new Invoice { InvoiceNumber = 3 }, 
                                   new Invoice { InvoiceNumber = 3 } 
                                 };
    invs.ForEach(i => i.IsDupe = true);
	invs.GroupBy (i => i.InvoiceNumber)
        .Select(g => g.First())
        .ToList()
        .ForEach(i => i.IsDupe = false);
	
