    protected void Application_Start()
    {
        IConfigurationSource source = ConfigurationSourceFactory.Create();
        DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(source));
        var logwriterFactory = new LogWriterFactory(source);
        var logWriter = logwriterFactory.Create();
        Logger.SetLogWriter(logWriter);
        var exceptionPolicyFactory = new ExceptionPolicyFactory(source);
        var exceptionManager = exceptionPolicyFactory.CreateManager();
        ExceptionPolicy.SetExceptionManager(exceptionManager);
    }
