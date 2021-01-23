    public class MainController : Controller
    
            {
                // GET: Main
                public ActionResult Index()
                {
                    
                        return View("MyView", new MyViewModel{ title = "blabla"});
        }
        }
