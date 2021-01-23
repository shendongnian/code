    public static void RegisterComponents(Startup startup)
    {
        var container = new UnityContainer();
        // registration
     
        startup.DataProtectionProviderFactory = container.Resolve<IDataProtectionProviderFactory>();
    }
