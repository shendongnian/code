    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var example = $"{ViewBag.Title}";
            ImASyntaxErrorWhatAmIWheresMySemicolonLOL
            return View();
        }
    } 
