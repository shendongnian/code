    namespace MyApp.Controllers
    {
        public class ProfessorController : Controller
        {    
            public ActionResult Index()
            {
                return View();
            }
        
        // Other ActionResults can return PartialView() 
        // so you don't have to refresh/rewrite the whole thing
        }
    }
