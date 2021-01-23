    async private void CapturePhoto_Click(object sender, RoutedEventArgs e)
    {
    ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
	InMemoryRandomAccessStream imageStream = new InMemoryRandomAccessStream();
	
	// take photo. Instead of saving to file, save it to stream so it can be manipulated.
    await captureManager.CapturePhotoToStreamAsync(imgFormat, imageStream);
    BitmapDecoder dec = await BitmapDecoder.CreateAsync(imageStream);
    BitmapEncoder enc = await BitmapEncoder.CreateForTranscodingAsync(imageStream, dec);
    string currentorientation = DisplayInformation.GetForCurrentView().CurrentOrientation.ToString();
    switch (currentorientation)
    {
        case "Landscape":
            enc.BitmapTransform.Rotation = BitmapRotation.None;
            break;
        case "Portrait":
            enc.BitmapTransform.Rotation = BitmapRotation.Clockwise90Degrees;
            break;
        case "LandscapeFlipped":
            enc.BitmapTransform.Rotation = BitmapRotation.Clockwise180Degrees;
            break;
        case "PortraitFlipped":
            enc.BitmapTransform.Rotation = BitmapRotation.Clockwise270Degrees;
            break;
        default:
            enc.BitmapTransform.Rotation = BitmapRotation.None;
            break;
    }
    await enc.FlushAsync();
	StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
        "Photo.jpg",
        CreationCollisionOption.ReplaceExisting);
	
    var filestream = await file.OpenAsync(FileAccessMode.ReadWrite);
    await RandomAccessStream.CopyAsync(imageStream, filestream);
	
	// Get photo as a BitmapImage 
    BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
    // imagePreivew is a <Image> object defined in XAML 
    imagePreview.Source = bmpImage;
    }
