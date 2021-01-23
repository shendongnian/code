    public static class UnityContainerBuilder
    {
        public static IUnityContainer BuildDirectInUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IService2, Service2>("Service2OneAndOnly", new ContainerControlledLifetimeManager());
            container.RegisterType<IService2, Service2_1>("Service2_1", new ContainerControlledLifetimeManager());
            container.RegisterType<IService3, Service3>(new ContainerControlledLifetimeManager());
            container.RegisterType<IService1, Service1>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(
                    new ResolvedParameter<IService2>("Service2OneAndOnly"),
                    new ResolvedParameter<IService3>()));
        }
    }
