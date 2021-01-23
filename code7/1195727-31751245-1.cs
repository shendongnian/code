    public class HomeController : Controller
            {
                private readonly IFooService fooService;
    
                public HomeController(IFooService fooService)
                {
                    this.fooService = fooService; //Daqui para frente é possível usar normalmente o service.
                }
            }
