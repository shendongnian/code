    BitmapImage bitmapImage = new BitmapImage();
    bitmapImage.BeginInit();
    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    bitmapImage.UriSource = new Uri(@"D:\Test" + listBox1.SelectedItem.ToString() + ".png", UriKind.Relative);
    bitmapImage.EndInit();
    newBrush.ImageSource = bitmapImage;
