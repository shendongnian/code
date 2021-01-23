	public class AppDependencyResolver
	{
		private static AppDependencyResolver _resolver;
		public static AppDependencyResolver Current
		{
			get
			{
				if (_resolver == null)
					throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
				return _resolver;
			}
		}
		public static void Init(IServiceProvider services)
		{
			_resolver = new AppDependencyResolver(services);
		}
		private readonly IServiceProvider _serviceProvider;
		public AppDependencyResolver(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public IUnitOfWorkFactory CreateUoWinCurrentThread()
		{
			var scopeResolver = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
			return new UnitOfWorkFactory(scopeResolver.ServiceProvider.GetRequiredService<DBData>(), scopeResolver);
		}
	}
