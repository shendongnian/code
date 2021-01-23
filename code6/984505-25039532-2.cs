    public class MyController : Controller
    {
        ApiCaller caller;
        public MyController()
        {
            //maybe inject this dependency
            ApiCaller = new ApiCaller();
        }
        public ActionResult Index()
        {
            SomeClass model = ApiCaller.Get();
            //do something with the instance if required
            return View(model);
        }
    }
