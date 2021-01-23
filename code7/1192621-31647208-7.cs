     public class HomeController
    
    // use the same patter which has been used in service 
    
    {
    
    private readonly IService _service;
    
    public HomeController(IService service)
    {
    _service=service;
    }
    
    
    public ActionResult Index()
    {
    
    return _service. GetUserDetails(/*userid*/);
    
    }
