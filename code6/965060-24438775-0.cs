    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                Response.Redirect("~/account/login");
            }
            int UserId = 1;
            var service = new UsersService(userRepository);
            service.Get(UserId);
            return View();
        }
      }
