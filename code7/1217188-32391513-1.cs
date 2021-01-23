    [Binding]
    public class Hooks
    {
    	private readonly IObjectContainer _objectContainer;
    
    	public Hooks(IObjectContainer objectContainer)
    	{
    		objectContainer = objectContainer;
    	}
    
    	[BeforeScenario]
    	public void RegisterServiceLocator()
    	{
    		var container = CreateContainer()
    		
    		var serviceLocator = new AutoFacServiceLocator(container)
    		
    		objectContainer.RegisterInstanceAs<IServiceLocator>(serviceLocator);
    	}
    
    	private Container CreateContainer() { /*Create your container*/}
    }
