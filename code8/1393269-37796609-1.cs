    public class HomeController : Controller
    {
        public ActionResult Index() {
            SearchQueryModel searchQuery = new SearchQueryModel() { TypeService = "Catégorisation" };
            return View(searchQuery);
        }
        [HttpPost]
        public ActionResult Index(SearchQueryModel query)
        {
            return View(query);
        }
    }
