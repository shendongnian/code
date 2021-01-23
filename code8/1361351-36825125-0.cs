    public static class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            builder.RegisterModule(new AutofacDataModule());
            builder.RegisterModule(new AutofacServiceModule());
            builder.RegisterType<WunderlistUserStore>().As<IUserStore<OwinUser,int>>().InstancePerRequest();
            builder.RegisterType<WunderlistRoleStore>().As<IRoleStore<OwinRole,int>>().InstancePerRequest();
            builder.RegisterType<WunderlistUserManager>().As<UserManager<OwinUser,int>>().InstancePerRequest();
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
