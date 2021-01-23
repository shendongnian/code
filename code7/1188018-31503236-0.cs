    public static void RegisterAccordingToISuperType<T>(this IWindsorContainer container)
    {
        if (typeof (T).GetInterfaces().Contains(typeof (ISuperType)))
            container.Register(Component.For<IRepository<T>>()
                                        .ImplementedBy<SuperRepository<T>>());
        else
            container.Register(Component.For<IRepository<T>>()
                                        .ImplementedBy<Repository<T>>());
    }
