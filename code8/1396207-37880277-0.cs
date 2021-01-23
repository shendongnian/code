    public ActionResult SendInvoice(SendInvoiceViewModel model)
    {
        var Invoice = db.Invoices.FirstOrDefault(x => x.Id == model.Id);
        MemoryStream ms = new MemoryStream(Invoice.Document);
    
        //Construct a file name for the attachment
        string filename = string.Format("{0}.pdf",Invoice.Number);
    
        Attachment Data = new Attachment(ms, fileName, MediaTypeNames.Application.Pdf);
        ContentDisposition Disposition = Data.ContentDisposition;
        Disposition.CreationDate = Invoice.Date;
        Disposition.ModificationDate = Invoice.Date;
        Disposition.ReadDate = Invoice.Date;
    
        SendInvoiceMail(model.EmailAddress, Invoice.Number, model.EmailMessage, Data);
    }
