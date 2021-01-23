                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(Global.PersonObject.Image);
                image.DecodePixelWidth = 275; // Important as we do not want to load the whole image
                image.EndInit();
                image.Freeze(); // Call this after EndInit and before using the image.
                PreviewIDPhoto.Source = image;
