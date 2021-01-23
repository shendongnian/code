            var sessionProvider = new SessionProvider(ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString);
    
            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register(typeof(IRepository<>), new[] { typeof(Repository<>).Assembly });
            container.RegisterSingleton<ICommandDispatcher>(new CommandDispatcher(container));
            container.Register(typeof(ICommandHandler<>), new[] { typeof(UserCommandsHandler).Assembly });
            /* here comes Session wiring ....*/
            container.Register(() => sessionProvider.SessionFactory, Lifestyle.Singleton);
            container.Register<ISession>(()=> container.GetInstance<ISessionFactory>().OpenSession(), Lifestyle.Scoped);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
