        public static void RegisterDBTypes(IUnityContainer container, string connection)
        {
            container.RegisterType<ADataContext>(new PerRequestLifetimeManager(), (new InjectionConstructor(connection)));
            container.RegisterType<RDataContext>(new PerRequestLifetimeManager(), (new InjectionConstructor(connection)));
            container.RegisterType<PDataContext>(new PerRequestLifetimeManager(), (new InjectionConstructor(connection)));
        }
