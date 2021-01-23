    public class User
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    
    	[DisplayName("Last Name")]
    	[JsonProperty(PropertyName = "last_name")]
    	public string LastName { get; set; }
    }
    
    public class HomeController : Controller
    {
    	public ActionResult Index()
    	{
    		var user = new User()
    		{
    			Id = 1, Name = "Julio", LastName = "Avellaneda"
    		};
    		
    		return View("Index", user);
    	}
    }
    
    public class UsersController : ApiController
    {
    	public HttpResponseMessage Get()
    	{
    		return Request.CreateResponse(HttpStatusCode.OK, new User
    		{
    			Id = 1, Name = "Julio", LastName = "Avellaneda"
    		});
    	}
    }
