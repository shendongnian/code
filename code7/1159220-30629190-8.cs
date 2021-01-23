     public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            var t = new TestBool();
            
           return View();
        }
        
        [HttpPost]
        public ActionResult Index(TestBool t)
        {
            return View("Index",t);
        }
      
       
    }
