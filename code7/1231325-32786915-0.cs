    protected override void ConfigureContainer(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException("container");
        }
        // Load default container
        container.LoadConfiguration();
        container.AddExtension(new ConfigExtension());
        // Load child configuration on top of first configuration
        container.LoadConfiguration(ConfigurationManager.AppSettings["ChildUnityContainer"]);
    }
