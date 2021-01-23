        if (list.SelectedIndex != -1)
        {
          var data = list.SelectedItem as ThumbItem;
          StorageFile newFile = await data.File.CopyAsync(ApplicationData.Current.LocalFolder);
          await SetWallpaperAsync(newFile);
        }
    
    async Task<bool> SetWallpaperAsync(StorageFile fileItem)
            {
                bool success = false;
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    success = await profileSettings.TrySetWallpaperImageAsync(fileItem);
                }
                return success;
            }
