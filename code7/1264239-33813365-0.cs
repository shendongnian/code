    public static void EditMimeTypesToWebApps(int EditType) // maybe you can make it an enum
    {
        var webApps = from svc in SPFarm.Local.Services.OfType<SPWebService>()
                      from SPWebApplication webApp in svc.WebApplications
                      where webApp.IsAdministrationWebApplication == false
                      select webApp;
        foreach (SPWebApplication webApp in webApps)
        {
            foreach (FileExtensionData fed in MimeTypes)
            {   
                if(EditType == 0)
                {
                    webApp.AllowedInlineDownloadedMimeTypes.Remove(fed.MimeType);
                }
                else
                {
                    webApp.AllowedInlineDownloadedMimeTypes.Add(fed.MimeType);
                }
            }
            webApp.Update();
        }
    }
