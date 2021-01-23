    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ModelTest model = new ModelTest {EnumTest = EnumTest.Test2};
            return View("View",model);
        }
    }
