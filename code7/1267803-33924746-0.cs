    public class HomeController : Controller
    { 
      ...
       public ActionResult Index()
       {
          List<SelectListItem> ddCompany = new List<SelectListItem>();
          //Code for populating ddCompany 
          return View(ddCompany);
       }
    }
