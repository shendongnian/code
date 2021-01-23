    public static void RegisterIoC(IAppBuilder app)
    {
        var container = new Container();
        container.RegisterPerWebRequest<IMyClient>(
            () =>
            {
                ...
