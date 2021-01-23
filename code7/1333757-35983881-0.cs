    private Stream stream = new MemoryStream();
    private CancellationTokenSource cts;
    
    private async void SelectImage(object sender, RoutedEventArgs e)
    {
        FileOpenPicker open = new FileOpenPicker();
        open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        open.ViewMode = PickerViewMode.Thumbnail;
    
        // Filter to include a sample subset of file types
        open.FileTypeFilter.Clear();
        open.FileTypeFilter.Add(".bmp");
        open.FileTypeFilter.Add(".png");
        open.FileTypeFilter.Add(".jpeg");
        open.FileTypeFilter.Add(".jpg");
    
        // Open a stream for the selected file
        StorageFile file = await open.PickSingleFileAsync();
    
        // Ensure a file was selected
        if (file != null)
        {
            // Ensure the stream is disposed once the image is loaded
            using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                BitmapImage bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(fileStream);
                fileStream.AsStream().CopyTo(stream);
                img.Source = bitmapImage;
            }
        }
    }
    
    private async void UploadImage(object sender, RoutedEventArgs e)
    {
        Uri uri = new Uri("you web uri");
        HttpClient client = new HttpClient();
        HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = streamContent;
        HttpResponseMessage response = await client.PostAsync(uri, streamContent).AsTask(cts.Token);
    }
