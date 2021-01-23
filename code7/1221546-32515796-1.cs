    namespace StackOverflow.Controllers
    {
        public class SomeController : Controller
        {
            //
            // GET: /Some/
    
            public ActionResult Index()
            {
                HomeController home = new HomeController();
    
                return home.Index("About");
            }
    
        }
    }
