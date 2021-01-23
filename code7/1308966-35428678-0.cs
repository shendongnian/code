            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<DbFactory>().As<IDbFactory>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().AsSelf().SingleInstance();
           // rest of code as singleInstance 
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>() { DataProtectionProvider = new DpapiDataProtectionProvider("Elhag.WebAPI") });
            builder.RegisterType<ApplicationUserManager>().AsSelf().SingleInstance();
            
            builder.Register(c=>new AuthorizationServerProvider(c.Resolve<ApplicationUserManager>())).AsImplementedInterfaces().SingleInstance();
            builder.Register(c => new UserStore<ApplictionUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().SingleInstance();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           return container;
