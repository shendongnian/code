    public static async Task<WriteableBitmap> GetProfilePictureAsync(string string userId)
    {
        StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync("ProfilePictures");
        StorageFile pictureFile = await pictureFolder.GetFileAsync(userId + ".jpg");
        using (IRandomAccessStream stream = await pictureFile .OpenAsync(FileAccessMode.Read))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            WriteableBitmap bmp = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            await bmp.SetSourceAsync(stream);
            return bmp;
        }
    }
