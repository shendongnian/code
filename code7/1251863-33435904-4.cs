    Image[] cards = ApplicationData.Current.LocalFolder.GetFolderAsync("Assets\\Cards").GetResults()
                           .GetFilesAsync().GetResults()
                           .Select(file =>
    {
           using(IRandomAccessStream fileStream = file.OpenAsync(Windows.Storage.FileAccessMode.Read).GetResults())
           {
               Image image = new Image();
               BitmapImage source = new BitmapImage();
               source.SetSourceAsync(fileStream).GetResults();
               image.Source = source;
               return image;
           }
    }).ToArray();
