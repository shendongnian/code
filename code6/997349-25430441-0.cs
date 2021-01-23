    public static UnhandledExceptionEventHandler TransformHandler(EventHandler<UnhandledExceptionEventArgs> handler)
    {
        return new UnhandledExceptionEventHandler(handler);
    }
    WeakEventHandler<UnhandledExceptionEventArgs>.Register(
        AppDomain.CurrentDomain,
        (s, eh) => s.UnhandledException += TransformHandler(eh),
        (s, eh) => s.UnhandledException -= TransformHandler(eh),
        this,
        (me, sender, ea) => me.UnhandledExceptionHandler(sender, ea)
    );
