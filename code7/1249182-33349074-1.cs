    [RoutePrefix("example-name")]
    public class example_nameController : Controller
    {
        // Route: example-name/Index
        [Route]
        public ActionResult Index()
        {
            return View();
        }
        // Route: example-name/Contact
        [Route]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
