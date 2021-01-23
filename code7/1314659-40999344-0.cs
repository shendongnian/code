        public static IUnityContainer RegisterMapper(this IUnityContainer container)
        {
            return container
            .RegisterType<MapperConfiguration>(new ContainerControlledLifetimeManager(), new InjectionFactory(c =>
                   new MapperConfiguration(configuration =>
                   {
                       configuration.ConstructServicesUsing(t => container.Resolve(t));
                       foreach (var profile in c.ResolveAll<Profile>())
                           configuration.AddProfile(profile);
                   })))
            .RegisterType<IConfigurationProvider>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => c.Resolve<MapperConfiguration>()))
            .RegisterType<IMapper>(new InjectionFactory(c => c.Resolve<MapperConfiguration>().CreateMapper()));
        }
