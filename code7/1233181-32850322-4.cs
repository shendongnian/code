       [HandleError]
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult SecureCall(String param)
            {
                return Json("token123456");
            }
    
            [HttpPost]
            public ActionResult DecryptResult(String param)
            {
                return Json("OK Got the decrypted token:" + param);
            }
    
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
    
                return View();
            }
    
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
    
                return View();
            }
        }
