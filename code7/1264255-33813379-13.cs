    public static void AddDownloadMimeTypesToWebApps(IEnumerable<SPWebApplication> webApps)
    {
        foreach (var webApp in webApps)
        {
            foreach (var fed in MimeTypes)
            {
                webApp.AllowedInlineDownloadedMimeTypes.Add(fed.MimeType);
            }
            webApp.Update();
        }
    }
