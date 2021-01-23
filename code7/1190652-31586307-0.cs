    public object GetInvoice(int invoiceID)
    {
    	var sum = yourContext.InvoiceItems
    		.Where(x => x.invoiceId == invoiceID)
    		.Select(x => x.quantity * x.price)
    		.Aggregate((a, b) => a + b);
    		
    	return yourContext.Invoices
    		.FirstOrDefault(x => x.Id == invoiceID)
    		.Select(invoice => new 
    		{
    			Invoice = invoice,
    			Total = sum
    		});
    }
