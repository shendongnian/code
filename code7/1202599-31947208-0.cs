    [RoutePrefix("Protected")]
    public class MyAccountController : Controller
    {
        [Route("Index")] //Route: /Protected/Index
        [Route("")] //Route : /Protected
        [Route("~/")] //Route : /
        public ActionResult Index()
        {
            return View();
        }
    }
