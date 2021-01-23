    public async Task CallFromAsync()
    {
        string blockingInvoiceId = UploadInvoice("assessment1", "filename");
    
        string asyncInvoiceId = await UploadInvoiceAsync("assessment1", "filename");
    }
