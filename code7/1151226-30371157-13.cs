    public class UserController : Controller
    {
         private IUserManagement_Services userManagementService;
    
         public UserController(IUserManagement_Services userManagementService)
         {
              this.userManagementService = userManagementService;
         }
    
         public ActionResult Index()
         {
              // The service will return a view model already populated with the users and groups
              UserGroup_ViewlModel model = userManagementService.GetUserAndGroups();
    
              return View(model);
         }
    }
