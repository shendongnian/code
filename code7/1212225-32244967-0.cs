    public class ProfileController : Controller
    {
        [Route("users/profile/{id}")]
        public ActionResult Index(int? id)
        {
            var user = id == null ? (UserModel)HttpContext.Session["CurrentUser"] : userManager.GetUserById((int)id);
            return View();
        }
    }
