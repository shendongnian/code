    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file1, string name1, string name2)
        {
            var result = new List<string>();
            if (file1 != null)
                result.Add(string.Format("{0}: {1} bytes", file1.FileName, file1.ContentLength));
            else
                result.Add("No file");
            result.Add(string.Format("name1: {0}", name1));
            result.Add(string.Format("name2: {0}", name2));
            return Content(string.Join(" - ", result.ToArray()));
        }
    }
