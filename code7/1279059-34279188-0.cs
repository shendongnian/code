    public DownloadContent()
        {
    
            AutoResetEvent ase = new AutoResetEvent(false);
    
            System.Threading.Tasks.Task.Factory.StartNew(()=>
    {
            adres = @"...";
    
            wb = new WebBrowser();
            
            wb.DocumentCompleted += (object sender, WebBrowserDocumentCompletedEventArgs e) => ase.Set(); //Here is the problem
            
            wb.Navigate(adres);
    });
    
    ase.WaitOne();
            MessageBox.Show("after"); //should print after OnDocumentCompleted
        }
