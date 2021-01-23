    // Call the async method from a non-async method
    public void CallFromNonAsync()
    {
        string blockingInvoiceId = UploadInvoice("assessment1", "filename");
                
        Task<string> task = Task.Run(async () => await UploadInvoiceAsync("assessment1", "filename"));
        task.Wait();
        string invoiceIdAsync = task.Result;
    }
    
    
    
    
