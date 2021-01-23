    [Authorize(Roles="Users")]
    public class UserController: Controller
    {
    }
    
    [Authorise(Roles="Employees")]
    public class EmployeeController: Controller
    {
    }
    [Authorize(Roles = "User,Customer")]
    public ActionResult RoleType()
    {                        
        return View();
    }
    
    public class MyController : Controller
    {
        private const string UserRole = "User";
        private const string EmployeeRole = "Employee";
     
        [Authorize(Roles = UserRole + "," + EmployeeRole)]
        public ActionResult UserOrEmployee()
        {                        
            return View();
        }
    }
