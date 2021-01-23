    public class TestController : Controller
    {
        // strParam and querystring will bound automatically, rename as appropriate
        public ActionResult Index(string strParam, string querystring)
        {
            // Do something with the values
            return View();
        }
    }
