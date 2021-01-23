    public class HomeController : Controller
    {
		private readonly IClassA classA;
	
		public HomeController(IClassA classA)
		{
			if (classA == null)
				throw new ArgumentNullException("classA");
		
			this.classA = classA;
		}
	
        public ActionResult Index()
        {
		    // Use this.classA here...
            // IService will be automatically injected to it.
		
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
    }
