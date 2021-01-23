    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var injuryValues = new Dictionary<string, int>();
            injuryValues.Add("test", 1);
            injuryValues.Add("test2", 2);
    
            ViewData["InjuryDictionary"] = injuryValues;
            return View();
        }
    }
