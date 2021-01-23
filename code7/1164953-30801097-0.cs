    // define on top
    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    //in constructor or in OnNavigatedTo()
     string sourceVal = localSettings.Values["ProfilePic"] as string;
     if (sourceVal != null)
            {
                //  Image img1 = new Image();
                BitmapImage bi = new BitmapImage();
                Uri uri = new Uri(sourceVal, UriKind.Relative);
                bi.UriSource = uri;
                img.Source = bi;
            }
            else
            {
                // hardcoding image source for testing. You can set image here from gallery
                img.Source = new BitmapImage(new Uri("/Assets/AlignmentGrid.png", UriKind.Relative));
            }
    // Save image (in OnNavigatedFrom())
    BitmapImage bitmapImage = img.Source as BitmapImage;
    string path = bitmapImage.UriSource.ToString();
    localSettings.Values["ProfilePic"] = path;
