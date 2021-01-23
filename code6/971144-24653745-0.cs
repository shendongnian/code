    private async static Task<string> CropAndSaveImage(string filePath)
    {
        const string croppedimage = "cropped_albumart.jpg";
        // read file
        StorageFile file = await StorageFile.GetFileFromPathAsync(filePath);
        if (file == null)
            return String.Empty;
        // create a stream from the file and decode the image
        var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
        // create a new stream and encoder for the new image
        using (InMemoryRandomAccessStream writeStream = new InMemoryRandomAccessStream())
        {
            // create encoder
            BitmapEncoder enc = await BitmapEncoder.CreateForTranscodingAsync(writeStream, decoder);
            enc.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
            // convert the entire bitmap to a 744px by 744px bitmap
            enc.BitmapTransform.ScaledHeight = 744;
            enc.BitmapTransform.ScaledWidth = 744;
            enc.BitmapTransform.Bounds = new BitmapBounds()
            {
                Height = 360,
                Width = 744,
                X = 0,
                Y = 192
            };
            await enc.FlushAsync();
            StorageFile albumartfile = await ApplicationData.Current.LocalFolder.CreateFileAsync(croppedimage, CreationCollisionOption.ReplaceExisting);
            using (var stream = await albumartfile.OpenAsync(FileAccessMode.ReadWrite))
            {
                await RandomAccessStream.CopyAndCloseAsync(writeStream.GetInputStreamAt(0), stream.GetOutputStreamAt(0));
            }
            // return image path
            return albumartfile.Path;
        }
    }
