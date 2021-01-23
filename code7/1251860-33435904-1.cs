    Task<Image[]> gettingCards = ApplicationData.Current.LocalFolder.GetFolderAsync("Assets\\Cards")
                                 .ContinueWith(assetsFolder => assetsFolder.Result.GetFilesAsync())
                                 .ContinueWith(files => files.Result.Select(
                                               file => file.OpenAsync(Windows.Storage.FileAccessMode.Read)
                                 .ContinueWith(fileStream =>
    {
        BitmapImage image = new BitmapImage();
        image.SetSourceAsync(fileStream.Result).Wait();
        fileStream.Result.Dispose();
        return image;
    })));
    gettingCards.Wait();
    Image[] cards = gettingCards.Result;
