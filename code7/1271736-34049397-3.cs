    public async Task GetFileFromServer()
    {
        await UploadFile();
        await DownloadFile();
    }
    
    public async Task UploadFile()
    {
        ...
    }
    
    public async Task DownloadFile()
    {
        WebBrowser webBrowser = new WebBrowser();
        webBrowser.Url = new Uri(MySpecificIP);
    
        await WaitBeforeDownloadFile(webBrowser);
        //Continue here
    }
