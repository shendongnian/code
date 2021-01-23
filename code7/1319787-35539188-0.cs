    private async void LoadImageAsync(object sender, System.Windows.RoutedEventArgs e)
    {
        await Task.Delay(100);
        var senderItem = sender as Image;
        if (senderItem != null)
        {
            var dataContext = senderItem.DataContext as FileDto;
            if (dataContext != null)
            {
                if (!string.IsNullOrEmpty(dataContext.ImageUrl))
                {
                    var image = new Image();
                    var fullFilePath = dataContext.ImageUrl;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();
                    image.Source = bitmap;
                    senderItem.Source = bitmap;
                }
            }
        }
    }
