    async Task<bool> SetWallpaperAsync(string localAppDataFileName)
    {
        bool success = false;
        var uri = new Uri($"ms-appx:///img/{localAppDataFileName}");
        //generate new file name to avoid colitions
        var newFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(localAppDataFileName)}";
        if (UserProfilePersonalizationSettings.IsSupported())
        {
            var profileSettings = UserProfilePersonalizationSettings.Current;
            var wfile = await StorageFile.GetFileFromApplicationUriAsync(uri);
            //Copy the file to Current.LocalFolder because TrySetLockScreenImageAsync
            //Will fail if the image isn't located there 
            using (Stream readStream = await wfile.OpenStreamForReadAsync(),
                          writestream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(newFileName,
                                         CreationCollisionOption.GenerateUniqueName)
                  )
            { await readStream.CopyToAsync(writestream); }
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(newFileName);
            success = await profileSettings.TrySetLockScreenImageAsync(file);
        }
        Debug.WriteLine(success);
        return success;
    }
