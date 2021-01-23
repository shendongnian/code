    [LoginFilter]
    public class Dashboard : Controller
    {
        public ActionResult Index()
        {
            // I'd like to be able to use the ID from the LoginFilter here
            int id = (int)ViewData["Id"];
        }
    }
