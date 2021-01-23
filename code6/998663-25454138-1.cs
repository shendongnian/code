    public override async void OnInitialized()
    {
        await PopulateImages();
        base.OnInitialized();
    }
    private async Task PopulateImages()
    {
       string StartDirectory = @"//path/to/network/folder";
       Directory.EnumerateFiles(StartDirectory)
                       .Select(filename => async () =>
                       {
                           Bitmap resizedImage;
                           using (var sourceStream = File.Open(filename, FileMode.Open))
                           using (var destinationStream = new MemoryStream())
                           {
                               await sourceStream.CopyToAsync(destinationStream);
                               resizedImage = ResizeImage(new Bitmap(destinationStream), 96, 96);
                           }
                       }
                       var imgControl = new ImageControl(filename, resizedImage);
                 stackpanelContainer.Children.Add(imgControl);
       
    }
