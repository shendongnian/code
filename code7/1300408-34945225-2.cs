    public class HomeController : Controller, IContactNumber
    {
        public string ContactNumber
        {
            get { return "0800 161 5192"; }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
