    var builder = new ConfigurationSourceBuilder();
    // Configure the dataSource (connection string)
    builder.ConfigureData()
        .ForDatabaseNamed( "TestDB" )
            .ThatIs.ASqlDatabase()
            // this would be determined at runtime; not statically defined
            .WithConnectionString( @"Data Source=.\SQLExpress;Initial Catalog=Logging;Integrated Security=True" )
        .AsDefault();
    // create a new config source
    var configSource = new DictionaryConfigurationSource();
    builder.UpdateConfigurationWithReplace( configSource );
    IUnityContainer container = new UnityContainer();
    // load the default configuration information from the config file
    // i.e. ConfigurationSourceFactory.Create()
    // and add it to the container
    container.AddNewExtension<EnterpriseLibraryCoreExtension>();
    // create a configurator to use to configure our fluent configuration
    var configurator = new UnityContainerConfigurator( container );
    EnterpriseLibraryContainer.ConfigureContainer( configurator, configSource );
    // Use the configured container with file and fluent config as the Enterprise Library service locator
    EnterpriseLibraryContainer.Current = new UnityServiceLocator( container );
    // Write a log entry using the Logger facade
    LogEntry logEntry = new LogEntry
    {
        EventId = 180,
        Priority = 1,
        Message = "Message",
        Categories = { "AccessAudit" }
    };
    Logger.Write( logEntry );
