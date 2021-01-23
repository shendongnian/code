    [System.Web.Services.WebMethod]
    public static string GetCurrentAssembly()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        string version = fileVersionInfo.ProductVersion;
      return version;
    }
