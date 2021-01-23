    public async static Task<StorageItemThumbnail> GetFileIcon(this StorageFile file, uint size = 32)
    {
        StorageItemThumbnail iconTmb;
        var imgExt = new[] { "bmp", "gif", "jpeg", "jpg", "png" }.FirstOrDefault(ext => file.Path.ToLower().EndsWith(ext));
        if (imgExt != null)
        {
            var dummy = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("dummy." + imgExt, CreationCollisionOption.ReplaceExisting); //may overwrite existing
            iconTmb = await dummy.GetThumbnailAsync(ThumbnailMode.SingleItem, size);
        }
        else
        {
            iconTmb = await file.GetThumbnailAsync(ThumbnailMode.SingleItem, size);
        }
        return iconTmb;
    }
