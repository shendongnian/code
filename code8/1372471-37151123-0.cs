    public class CaseController : Controller
    {
      [HttpPost]
      public ActionResult Index(Case case)
        { 
          //Do Something
          return View();
        }
        public ActionResult Index()
        {
           
         return View();
        }
    }
