    public static void RegisterEntityFramework<TContext>(this Container container, Func<TContext> context) where TContext : DbContext
    {
    	if (container == null) throw new ArgumentNullException(nameof(container));
    
    	var contextProducer = Lifestyle.Scoped.CreateProducer<DbContext>(context, container);
    	container.RegisterSingleton<Func<DbContext>>(() => contextProducer.GetInstance);
    }
    
    var userContext = new AspNetHttpUserContext();
    var container = new Container();
    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
    container.RegisterSingleton<IUserContext>(userContext);
    container.RegisterEntityFramework(() => new WayFinderDbContext(userContext));
    container.Verify();
