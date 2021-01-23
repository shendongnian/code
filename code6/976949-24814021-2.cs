    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(BigViewModel model)
        {
            var smallVIewModelInfo = model.SmallView.Stuff;
            var bigViewModelConfirm = model.Confirm;
            return View();
        
    }
        }
