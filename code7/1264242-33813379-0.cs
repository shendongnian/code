    public static IEnumerable<SPWebApplication> GetWebApps()
    {
        var webApps = from svc in SPFarm.Local.Services.OfType<SPWebService>()
                      from SPWebApplication webApp in svc.WebApplications
                      where webApp.IsAdministrationWebApplication == false
                      select webApp;
        return webApps;   
    }
