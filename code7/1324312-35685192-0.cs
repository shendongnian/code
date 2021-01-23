    [Authorize(Roles = "Admin")]
    public class SecretsController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(...);
        }
    
        ...
    }
