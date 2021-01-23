    public class ErrorController : Controller
        {
            // GET: Error
            public ActionResult Index()
            {
                return View();
            }
    
            public ViewResult Error404()
            {
                return View();
            }
    
            public ViewResult Error500()
            {
                return View();
            }
    
            public ViewResult Error400()
            {
                return View();
            }
    
            public ActionResult General()
            {
                return View();
            }
        }
