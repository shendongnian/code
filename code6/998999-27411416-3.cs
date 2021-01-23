    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        //Initialize Items
        List<IThumbnailedImage> theImages = new List<IThumbnailedImage>();
        mvControl.Items = new ObservableCollection<object>(theImages);
    
        //Begin downloading images.
        await LoadImages();
    }
    
    private async Task LoadImages()
    {
        try
        {
            await LoadFromOnlineMedia();
        }
        catch (Exception ex)
        {
            string pauseHere = "";
        }
    }
    
    private async Task LoadFromOnlineMedia()
    {
        await DownloadImageFile("http://www.fnordware.com/superpng/pnggrad16rgb.png");
        await DownloadImageFile("http://www.fnordware.com/superpng/pnggrad16rgba.png");
        await DownloadImageFile("http://www.fnordware.com/superpng/pngtest16rgba.png");
    }
    
    private async Task DownloadImageFile(string imageUrl)
    {
        WebClient theClient = new WebClient();
        theClient.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
        theClient.OpenReadAsync(new System.Uri(imageUrl));
    }
    
    void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        //Add Image to the Items collection via the UI Thread.
        Dispatcher.BeginInvoke(() => { mvControl.Items.Add(new OnlineMediaThumbnailedImage(e.Result)); });
    }
