    async Task<bool> SetWallpaperAsync(string localAppDataFileName)
    {
        var imgPath = Path.Combine(Package.Current.InstalledLocation.Path, "img", localAppDataFileName);
        bool success = false;
        if (UserProfilePersonalizationSettings.IsSupported())
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(imgPath);
            UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
            success = await profileSettings.TrySetLockScreenImageAsync(file);
        }
        Debug.WriteLine(success);
        return success;
    }
