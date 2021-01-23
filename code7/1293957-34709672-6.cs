    // read Web.Config
    Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
    container.AddSingleton<IConfiguration<AppConfiguration>>(new DefaultConfiguration<AppConfiguration>(
        new AppConfiguration
        {
            OneOption = rootWebConfig.AppSettings.Settings["oneSetting"],
            OtherOption = rootWebConfig.AppSettings.Settings["otherSetting"],
        })
    );
