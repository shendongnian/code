    // set all default prefix to /Security path
    [RoutePrefix("Security")]
    public class SecurityController : Controller
    {
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
    }
