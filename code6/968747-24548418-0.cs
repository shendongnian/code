     public IHttpActionResult AssignAccountCodesToInvoiceById (int id)
    {
    
     var invoice = _invoiceRepository.Get(id);
    
            if (invoice == null) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invoice not found"));
    
            ....
        }
