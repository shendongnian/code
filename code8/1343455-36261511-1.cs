    private readonly string _siteLogo = new Lazy<string>(() => WebConfigurationManager.AppSettings["SITE_LOGO"]);
    // Lazy<T>.Value will call the factory delegate you gave
    // as Lazy<T> constructor argument
    public string SiteLogo => _siteLogo.Value;
            
