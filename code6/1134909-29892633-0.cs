    [Authorize(Roles = "Manager")] //role1
    public class YourController : Controller
    {
        [Authorize(Roles = "Finance")] //role2
        public ActionResult Index()
        {
        }
    }
