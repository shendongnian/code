    public static void RegisterDependencies()
        {
            try
            {
                // Use this class to set configuration options for your mobile service
                ConfigOptions options = new ConfigOptions();
                // Use this class to set WebAPI configuration options
                HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options, (configuration, builder) =>
                {
                    //Register API controllers
                    builder.RegisterApiControllers(typeof(UserController).Assembly);
                    /*Register Libs*/
                    builder.RegisterType<UserLib>().As<IUserLib>();
                    /*Register ObjectContexts*/
                    builder.RegisterType<MobileServiceContext>().As<DbContext>().InstancePerDependency();
                    /*Register DataRepository Here*/
                    builder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IDataRepository<>));
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
