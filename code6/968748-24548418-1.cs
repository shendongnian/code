      [ResponseType(typeof(AccountCodeAssignment))]
             public IHttpActionResult AssignAccountCodesToInvoiceById (int id)
            {
            
             var invoice = _invoiceRepository.Get(id);
            
                    if (invoice == null) {
    
                    return NotFound();
             }
            
        
        
                   return Ok(invoice);
                }
