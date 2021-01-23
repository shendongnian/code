    public static Container GetInitializeContainer(IAppBuilder app)
    {
        var container = new Container();
        // IoC for ASP.NET Identity
        container.RegisterSingleton<IAppBuilder>(app);
        container.RegisterPerWebRequest<ApplicationUserManager>();
        container.RegisterPerWebRequest<ApplicationDbContext>(
            () => new ApplicationDbContext("Your constring goes here"));
        container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(
            () => new UserStore<ApplicationUser>(
                container.GetInstance<ApplicationDbContext>()));
        container.RegisterInitializer<ApplicationUserManager>(
            manager => InitializeUserManager(manager, app));
        // Setup for ISecureDataFormat
        container.RegisterWebApiRequest<ISecureDataFormat<AuthenticationTicket>, 
            SecureDataFormat<AuthenticationTicket>>();
        container.RegisterWebApiRequest<ITextEncoder, Base64UrlTextEncoder>();
        container.RegisterWebApiRequest<IDataSerializer<AuthenticationTicket>, 
            TicketSerializer>();
        container.RegisterWebApiRequest<IDataProtector>(
            () => new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider()
                .Create("ASP.NET Identity"));
        // Register all controllers
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        return container;
    }
