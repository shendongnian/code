    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                ShowElement1 = myObj.IsAllowed,
                PageLabel = someotherObj.PersonName
            };
            
            return View(model);
        }
    }
   
