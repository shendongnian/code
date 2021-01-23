    [Binding]
    public class Hooks
    {
    	private readonly IObjectContainer _objectContainer;
    
    	public Hooks(IObjectContainer objectContainer)
    	{
    		_objectContainer = objectContainer;
    	}
    
    	[BeforeScenario]
    	public void RegisterServiceLocator()
    	{
    		var container = CreateContainer();
    		
    		var serviceLocator = new AutoFacServiceLocator(container);
    		
    		_objectContainer.RegisterInstanceAs<IServiceLocator>(serviceLocator);
    	}
    
    	private IContainer CreateContainer() { /*Create your container*/}
    }
