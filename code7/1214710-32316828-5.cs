    public class SomeController : Controller
    {
    	private readonly UserFactory _userFactory;	
    
    	public SomeController(UserFactory userFactory)
    	{
    		_userFactory = userFactory;
    	}
    
    	// ...
    }
