    public class HomeController
    {
         [HttpGet]
         public ActionResult Index()
         {
             var viewModel = new ViewModel();
             viewModel.UserInfo = new List<UserInfo>();
             // build your collection...
             return View(viewModel);
         }
    }
