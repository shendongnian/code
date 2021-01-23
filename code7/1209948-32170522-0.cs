    public static void Register(HttpConfiguration config)
    {
        var container = new Container();
        container.RegisterWebApiRequest<IRepositoryAsync<Category>, Repository<Category>>();
        container.RegisterWebApiRequest<ICategoryService, CategoryService>();
        container.RegisterWebApiRequest<IDataContextAsync>(() => new MyContext());
        container.Verify();
        config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        // Other Web API configuration not shown.
    }
