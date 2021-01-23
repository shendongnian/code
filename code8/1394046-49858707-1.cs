    public class HomeController : Controller
    {
        private readonly IRepository repo;
        /// <summary>
        /// MVC receives an incoming request to an action method on the Home controller. 
        /// MVC asks the ASP.NET service provider component for a new instance of the HomeController class.
        /// The service provider inspects the HomeController constructor and discovers that it has a dependency on the IRepository interface. 
        /// The service provider consults its mappings to find the implementation class it has been told to use for dependencies on the IRepository interface. 
        /// The service provider creates a new instance of the implementation class. 
        /// The service provider creates a new HomeController object, using the implementation object as a constructor argument.
        /// The service provider returns the newly created HomeController object to MVC, which uses it to handle the incoming HTTP request.
        /// </summary>
        /// <param name="repo"></param>
        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        ///  Using Action Injection
        ///  MVC uses the service provider to get an instance of the ProductTotalizer class and provides it as an
        ///  argument when the Index action method is invoked.Using action injection is less common than standard
        ///  constructor injection, but it can be useful when you have a dependency on an object that is expensive to
        ///  create and that is required in only one of the action methods defined by a controller
        /// </summary>
        /// <param name="totalizer"></param>
        /// <returns></returns>
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            ViewBag.Total = totalizer.repository.ToString();
            ViewBag.HomeCotroller = repo.ToString();
            return View(repo.Products);
        }
    }
