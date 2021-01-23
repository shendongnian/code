    [Authorize(Roles = "Admin")]
    public class SecretsController : Controller
    {
        
        [OverrideAuthorization]
        [Authorize()]
        public ActionResult Index()
        {
            return View(...);
        }
        ...
    }
