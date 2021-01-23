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
               // Modify Image properties here...
               // image.Margin = new Thicknes(0, 0, 0, 0);
               // ....
               // You can also do LayoutRoot.Children.Add(image);
               return image;
           }
    }).ToArray();
