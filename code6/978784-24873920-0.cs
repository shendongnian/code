    BitmapImage image = new BitmapImage();
    image.BeginInit();
    image.UriSource = new Uri("/images/low_battery.png", UriKind.Relative);
    image.DownloadFailed += image_DownloadFailed;
    image.EndInit();
    
    imageIcon.ImageFailed += imageIcon_ImageFailed;
    imageIcon.Source = image;
    imageIcon.Visibility = System.Windows.Visibility.Visible;
