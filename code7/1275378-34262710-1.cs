    public MainPage()
    {
        this.InitializeComponent();
    
        ...
        inkCanvas.InkPresenter.StrokesCollected += InkPresenter_StrokesCollected;
        inkCanvas.InkPresenter.StrokesErased += InkPresenter_StrokesErased;
    }
    private async void InkPresenter_StrokesErased(InkPresenter sender, InkStrokesErasedEventArgs args)
    {
        var image = await SaveAsync();
        MyImage.Source = image;
    }
    
    private async void InkPresenter_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
    {
        var image = await SaveAsync();
        MyImage.Source = image;
    }
    private async Task<BitmapImage> SaveAsync()
    {
        var bitmap = new BitmapImage();
    
        if (inkCanvas.InkPresenter.StrokeContainer.GetStrokes().Count > 0)
        {
            try
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
                    stream.Seek(0);
                    bitmap.SetSource(stream);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        return bitmap;
    }
