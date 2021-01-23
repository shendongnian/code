    public void mainMethod() 
    {
        Thread.Sleep(60000);
        doDownload();
    }
    
    public void doDownload() 
    {
        Task.Factory.StartNew(() => {
            // Background download
        }).ContinueWith(task => mainMethod());
    }
