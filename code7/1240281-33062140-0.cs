    public static Func<IDbLogger> LoggerGetter {get;set}
    public static static Log(string text)
    {
        LoggerGetter().Log(text); // will resolve `IDbLogger` at this point
    }
    ....
    // during container initialization:
    container.Register<IDbLogger>(....);
    Logger.LoggerGetter = container.Resolve<Func<IDbLogger>>();
