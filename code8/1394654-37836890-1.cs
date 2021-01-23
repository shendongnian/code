    async Task MyMethod()
    {
        UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
        await ViewModel.LoadData();
        UserDialogs.Instance.HideLoading();
    }
    
    //InsideViewModel
    public async Task LoadData()
    {
        await DownloadFileAsync("http://url.to.some/file.mp3", "file.mp3");
    }
    
    public async Task DownloadFileAsync(string url, string filename) 
    {
        var destination = Path.Combine(
        System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.ApplicationData),
            filename);
    
        await new WebClient().DownloadFileTaskAsync(new Uri(url), destination);
    } 
