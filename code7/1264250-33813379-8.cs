    public static void DeleteDownloadMimeTypesFromWebApps(IEnumerable<SPWebApplication> webApps)
    {
        foreach (var webApp in webApps)
        {
            foreach (var fed in MimeTypes)
            {
                webApp.AllowedInlineDownloadedMimeTypes.Remove(fed.MimeType);
            }
            webApp.Update();
        }
    }
