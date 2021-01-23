    // In WPF app this method is wired up to a DelegateCommand
    public void ButtonClickEventHandler(object sender, EventArgs e)
    {
        DownloadStuffAsync().Wait();
    }
    public async Task DownloadStuffAsync()
    {
        Console.WriteLine("Start GetStringAsync");
        string page = await new HttpClient().GetStringAsync("http://www.ibm.com");
        Console.WriteLine("End GetStringAsync");
    }
