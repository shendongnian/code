    using (FileStream fileStream = File.OpenRead(@"D:\Test" + listBox1.SelectedItem.ToString() + ".png"))
    {
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = fileStream;
        bitmapImage.EndInit();
        newBrush.ImageSource = bitmapImage;
    }
