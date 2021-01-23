    public class UserController : Controller
    {
         private IUserManagement_Services userManagementService;
    
         public UserController(IUserManagement_Services userManagementService)
         {
              this.userManagementService = userManagementService;
         }
    
         public ActionResult Index()
         {
              userManagementService model = userManagementService.GetUserAndGroups();
    
              return View(model);
         }
    }
