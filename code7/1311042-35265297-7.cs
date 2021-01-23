    public static void ConfigureLog4Net(this IApplicationEnvironment appEnv, string configFileRelativePath)
    {
        GlobalContext.Properties["appRoot"] = appEnv.ApplicationBasePath;
        XmlConfigurator.Configure(new FileInfo(Path.Combine(appEnv.ApplicationBasePath, configFileRelativePath)));
    }
    public static void AddLog4Net(this ILoggerFactory loggerFactory, Func<string, bool> sourceFilterFunc = null)
    {
        loggerFactory.AddProvider(new Log4NetProvider(sourceFilterFunc));
    }
    public static void AddLog4Net(this ILoggerFactory loggerFactory)
    {
        loggerFactory.AddLog4Net(null);
    }
