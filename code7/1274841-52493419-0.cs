    public partial class AccountController : Controller
    {
            [HttpGet]
            [OutputCache(NoStore = true, Duration = 0)]
            public virtual ActionResult Index()
            {
                if (User.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Home");
                LoginModel model = new LoginModel();
                return View(model);
            }
    }
