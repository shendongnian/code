    Image[] cards = ApplicationData.Current.LocalFolder.GetFolderAsync("Assets\\Cards").GetResults()
                           .GetFilesAsync().GetResults()
                           .Select(file =>
    {
           using(IRandomAccessStream fileStream = file.OpenAsync(Windows.Storage.FileAccessMode.Read).GetResults())
           {
               BitmapImage image = new BitmapImage();
               image.SetSourceAsync(fileStream).GetResults();
               return image;
           }
    }).ToArray();
