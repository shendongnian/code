    public static IAppBuilder CreatePerOwinContext<T>(this IAppBuilder app,
        Func<IdentityFactoryOptions<T>, IOwinContext, T> createCallback,
        Action<IdentityFactoryOptions<T>, T> disposeCallback) where T : class, IDisposable
    {
        if (app == null)
        {
            throw new ArgumentNullException("app");
        }
        if (createCallback == null)
        {
            throw new ArgumentNullException("createCallback");
        }
        if (disposeCallback == null)
        {
            throw new ArgumentNullException("disposeCallback");
        }
        app.Use(typeof (IdentityFactoryMiddleware<T, IdentityFactoryOptions<T>>),
            new IdentityFactoryOptions<T>
            {
                DataProtectionProvider = app.GetDataProtectionProvider(),
                Provider = new IdentityFactoryProvider<T>
                {
                    OnCreate = createCallback,
                    OnDispose = disposeCallback
                }
            });
        return app;
    }
