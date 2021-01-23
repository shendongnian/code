    Image[] gettingCards = ApplicationData.Current.LocalFolder.GetFolderAsync("Assets\\Cards").GetResult()
                           .GetFilesAsync().GetResult()
                           .Select(file =>
    {
           using(IRandomAccessStream fileStream = file.OpenAsync(Windows.Storage.FileAccessMode.Read).GetResult())
           {
               BitmapImage image = new BitmapImage();
               image.SetSourceAsync(fileStream).GetResult();
               return image;
           }
    }).ToArray();
