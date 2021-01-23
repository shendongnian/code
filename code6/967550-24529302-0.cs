    [HttpPost]
    public ActionResult Login(Acccount obj){
    // check whether the user login is valid or not
        if(UseIsValid){
            FormsAuthentication.SetAuthCookie(obj.username, obj.RememberMe);
            return redirectToAction("Index","DashBoard");
        }
        return View(obj);
    }
*
    and Use [Authorize] attribute. like*
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
    }
