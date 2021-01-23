    [Authorize(Roles = "role1, role2, role3")] 
    public class YourController : Controller
    {
        [Authorize(Roles = "role4, role5, role6")]  
        public ActionResult Index()
        {
        }
    }
