    public static async Task<WriteableBitmap> GetProfilePicture(string userId)
    {
        StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync("ProfilePictures");
        StorageFile pictureFile = await pictureFolder.GetFileAsync(userId + ".jpg");
        using (IRandomAccessStream stream = await pictureFile .OpenAsync(FileAccessMode.Read))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            WriteableBitmap bmp = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            bmp.SetSource(stream);
            return bmp;
        }
    }
