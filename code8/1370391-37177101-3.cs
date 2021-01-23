    public static Container GetInitializeContainer(IAppBuilder app)
    {
        var container = new Container();
        // IoC for ASP.NET Identity
        container.RegisterSingleton<IAppBuilder>(app);
        container.Register<ApplicationUserManager>(Lifestyle.Scoped);
        container.Register<ApplicationDbContext>(
            () => new ApplicationDbContext("Your constring goes here"),
            Lifestyle.Scoped);
        container.Register<IUserStore<ApplicationUser>>(
            () => new UserStore<ApplicationUser>(
                container.GetInstance<ApplicationDbContext>()),
            Lifestyle.Scoped);
        container.RegisterInitializer<ApplicationUserManager>(
            manager => InitializeUserManager(manager, app));
        // Setup for ISecureDataFormat
        container.Register<ISecureDataFormat<AuthenticationTicket>, 
            SecureDataFormat<AuthenticationTicket>>(Lifestyle.Scoped);
        container.Register<ITextEncoder, Base64UrlTextEncoder>(Lifestyle.Scoped);
        container.Register<IDataSerializer<AuthenticationTicket>, 
            TicketSerializer>(Lifestyle.Scoped);
        container.Register<IDataProtector>(
            () => new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider()
                .Create("ASP.NET Identity"),
            Lifestyle.Scoped);
        // Register all controllers
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        return container;
    }
