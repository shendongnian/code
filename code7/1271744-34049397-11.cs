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
    
        //Initiate whatever here before waiting for the Navigated event
        await WaitBeforeDownloadFile(webBrowser);
        //Continue here
    }
