    private static void DownloadMimeTypesToWebApps(Action<SPWebApplication,FileExtensionData> action)
    {
        var webApps = from svc in SPFarm.Local.Services.OfType<SPWebService>()
                  from SPWebApplication webApp in svc.WebApplications
                  where webApp.IsAdministrationWebApplication == false
                  select webApp;
	    foreach (SPWebApplication webApp in webApps)
	    {
		   foreach (FileExtensionData fed in MimeTypes)
		   {
		       action.Invoke(webApp,fed);
		   }
		   webApp.Update();
	    }	
    
    }
    
    public static void AddDownloadMimeTypesToWebApps()
    {
    	DownloadMimeTypesToWebApps((webApp,fed) => webApp.AllowedInlineDownloadedMimeTypes.Add(fed.MimeType));
    }
    
    public static void DeleteDownloadMimeTypesToWebApps()
    {
     	DownloadMimeTypesToWebApps((webApp,fed) => webApp.AllowedInlineDownloadedMimeTypes.Remove(fed.MimeType));        
    }
