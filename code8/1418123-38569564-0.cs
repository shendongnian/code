    public ShippingDocumentsRegisterViewModel()
    {
        BW.DoWork += UpdateDocumentsListFromServer;
        BW.RunWorkerCompleted += BW_RunWorkerCompleted;
    
        BW.WorkerReportsProgress = true;
        BW.ProgressChanged += UpdateGui;
        BW.RunWorkerAsync();
    }
    public void UpdateGui(object o, EventArgs args)
    {
        foreach (var item in tempDocuments)
        {
            this.shippingDocuments.Add(item);
        }
    }
    public void UpdateDocumentsListFromServer(object o, EventArgs args)
    {
    
        while (true) {
        	System.Threading.Thread.Sleep(3000);
        
        	tempDocuments = GetDocumentsFromServer();
        	BW.ReportProgress(0);
        	
        }
    }
    int num = 0;
    public ShippingDocument[] GetDocumentsFromServer()
        {
            System.Threading.Thread.Sleep(3000);
            return new ShippingDocument[1] { new ShippingDocument { Name = "Test" + num++} };
        }
    private ShippingDocument[] tempDocuments = new ShippingDocument[0];
