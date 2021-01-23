    public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add all the ASP services here
            // #region ASP
            services.AddOptions();
            services.Configure<WcfOptions>(Configuration.GetSection("wcfOptions"));
            var globalAuthFilter = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            services.AddMvc(options => { options.Filters.Add(new AuthorizeFilter(globalAuthFilter)); })
                    .AddJsonOptions
                (
                    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                );
            // #endregion ASP
            // Creating the UnityServiceProvider
            var unityServiceProvider = new UnityServiceProvider();
            IUnityContainer container = unityServiceProvider.UnityContainer;
            // Adding the Controller Activator
            // Caution!!! Do this before you Build the ServiceProvider !!!
            services.AddSingleton<IControllerActivator>(new UnityControllerActivator(container));
            //Now build the Service Provider
            var defaultProvider = services.BuildServiceProvider();
            // Configure UnityContainer
            // #region Unity
            //Add the Fallback extension with the default provider
            container.AddExtension(new UnityFallbackProviderExtension(defaultProvider));
            // Register custom Types here
            container.RegisterType<ITest, Test>();
            container.RegisterType<HomeController>();
            container.RegisterType<AuthController>();
            // #endregion Unity
            return unityServiceProvider;
        }
