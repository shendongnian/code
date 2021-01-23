	var query =
		from valid in (
			 from contract in validContracts
			 from invoice in contract.InvoiceList
			 select new { contract, invoice }
		)
		join request in (
			from contract in paymentRequest.Contracts
			from invoice in contract.Invoices
			select new { contract, invoice }
		)
		on new { valid.contract.ContractId, valid.invoice.InvoiceNumber }
		equals new { request.contract.ContractId, request.invoice.InvoiceNumber }
		where request.invoice.CurrentDueAmount > valid.invoice.CurrentDueAmount
		select "Invoice Number: " + request.invoice.InvoiceNumber + ", Current Due >= " + valid.invoice.CurrentDueAmount;
