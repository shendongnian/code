    public class HomeController : Controller
    {
        private PrinterEntities db = new PrinterEntities();
        public ActionResult Index()
        {
            List<string> catlist = new List<string>();
            foreach (var item in db.C_Network)
            {
               if (CheckInternetConnection(item.IPAdresi))
                 catlist.Add(item.IPAdresi);
            }
        }
        ViewData["List"] = catlist;
        return View();
    }
    
