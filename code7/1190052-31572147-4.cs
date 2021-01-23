    public class AppSettings
    {
      public string SiteTitle { get; set; }
      public AppSettingsTenants Tenants { get; set; } = new AppSettingsTenants();
    }
    public class AppSettingsTenants
    {
      public string ReservedSubdomains { get; set; }
      public List<string> ReservedSubdomainList
      {
         get { return !string.IsNullOrEmpty(ReservedSubdomains) ? ReservedSubdomains.Split(',').ToList() : new List<string>(); }
      }
    }
