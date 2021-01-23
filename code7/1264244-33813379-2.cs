    public static void DeleteDownloadMimeTypesFromWebApps()
    {
        var webApps = GetWebApps();
    
        foreach (SPWebApplication webApp in webApps)
        {
            foreach (FileExtensionData fed in MimeTypes)
            {
                webApp.AllowedInlineDownloadedMimeTypes.Remove(fed.MimeType);
            }
            webApp.Update();
        }
    }
