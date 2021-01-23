    private static void ImageSourceStringChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        CustomImage currentImage = obj as CustomImage;
        string oldValue = e.OldValue as string;
        string newValue = e.NewValue as string;
        MainPage.logMsg("ImageSource = " + newValue);
        if (oldValue == null || !oldValue.Equals(newValue))
        {
            string path = newValue;
            if (string.IsNullOrEmpty(path))
            {
                Uri imageFileUri = new Uri("ms-appx:///Assets/Images/failed.png");
                currentImage.mainImage.ImageSource = new BitmapImage(imageFileUri);
            }
            else
            {
                Uri imageFileUri = null;
                try
                {
                    imageFileUri = new Uri(path);
                }
                catch
                {
                    imageFileUri = new Uri("ms-appx:///Assets/Images/failed.png");
                }
                if (imageFileUri != null)
                {
                    currentImage.mainImage.ImageSource = new BitmapImage(imageFileUri);
                }
            }
        }
    }
