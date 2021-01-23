    public static void AddDownloadMimeTypesToWebApps()
    {
        var webApps = GetWebApps();
        foreach (var webApp in webApps)
        {
            foreach (var fed in MimeTypes)
            {
                webApp.AllowedInlineDownloadedMimeTypes.Add(fed.MimeType);
            }
            webApp.Update();
        }
    }
