	public static IDependencyResolver RegisterUnity(string containerName)
	{
		var container = new UnityContainer();
		container.AddNewExtension<MyContainerExtension>();
		return new UnityResolver(container);
	}
	public class MvcSiteMapProviderContainerExtension
		: UnityContainerExtension
	{
		protected override void Initialize()
		{
			// Register data services
		
			// Important: In Unity you must give types a name in order to resolve an array of types
			this.Container.RegisterType<IDataService, TestDataService>("TestDataService");
			this.Container.RegisterType<IDataService, ProdDataService>("ProdDataService");
			
			// Register strategy
			
			this.Container.RegisterType<IDataServiceStrategy, DataServiceStrategy>(
				new InjectionConstructor(new ResolvedParameter<IDataService[]>()));
		}
	}
