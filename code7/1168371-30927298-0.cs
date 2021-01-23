    public override Stream Open()
    {
        // Set the response headers here. It's a bit hacky.
        HttpCachePolicy cache = HttpContext.Current.Response.Cache;
        cache.SetCacheability(HttpCacheability.Public);
        cache.VaryByHeaders["Accept-Encoding"] = true;
        IFileSystem azureBlobFileSystem = FileSystemProviderManager.Current.GetUnderlyingFileSystemProvider("media");
        int maxDays = ((AzureBlobFileSystem)azureBlobFileSystem).FileSystem.MaxDays;
        cache.SetExpires(DateTime.Now.ToUniversalTime().AddDays(maxDays));
        cache.SetMaxAge(new TimeSpan(maxDays, 0, 0, 0));
        cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        return this.stream();
    }
