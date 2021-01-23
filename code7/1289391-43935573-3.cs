    public class ModulesModule : IModule
    {
    	IRegionManager	_regionManager;
    	IUnityContainer _container;
    	public ModulesManagementModule( RegionManager regionManager, IUnityContainer container )
    	{
    		_regionManager	= regionManager;
    		_container	= container;
    	}
    	public void Initialize()
    	{
    		_container.RegisterTypeForNavigation<ViewA>();
    		_regionManager.RequestNavigate("ViewA", "ViewA" );
    	}
    }
