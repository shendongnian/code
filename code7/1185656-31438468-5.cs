    IUnityContainer container = new UnityContainer();
    container.RegisterTypes(
        AllClasses.FromAssembliesInBasePath().Where(t => typeof(BaseClass).IsAssignableFrom(t))
            .Select(t => typeof(Superman<>).MakeGenericType(t)),
        t => new Type[] { typeof(ISuperman) },
        t => t.GetGenericArguments().First().Name,
        WithLifetime.Transient);
    container.RegisterType<IEnumerable<ISuperman>, ISuperman[]>();
    container.Resolve<MainViewModel>();
