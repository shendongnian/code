    var query =
        from request in (
            from contract in paymentRequest.Contracts
            from invoice in contract.Invoices
            select new { contract, invoice }
        )
        join valid in (
             from contract in validContracts
             from invoice in contract.InvoiceList
             select new { contract, invoice }
        )
        on new { request.contract.ContractId, request.invoice.InvoiceNumber }
        equals new { valid.contract.ContractId, valid.invoice.InvoiceNumber }
        into validRequests
        where !validRequests.Any()
        select request;
