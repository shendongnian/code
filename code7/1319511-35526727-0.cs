    foreach (var contract in payment.Contracts)
    {
    	var otherContract = contracts.First(c => c.ContractId == contract.ContractId);
    	var missingInvoiceNumbers = contract.Invoices.Where(i => !otherContract.Invoices.Any(inv => inv.InvoiceNumber == i.InvoiceNumber))
                                                     .Select(i => i.InvoiceNumber);
    	// do something with the results, like adding them to a dictionary <contract.ContractId, missingInvoiceNumbers>
    }
