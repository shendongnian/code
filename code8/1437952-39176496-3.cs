    [RouteArea("Admin")]
    [RoutePrefix("Users")]
    public class UsersController : Controller {
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;
        public UsersController(
            IUsersService usersService,
            IRolesService rolesService) {
            _usersService = usersService;
            _rolesService = rolesService;
        }
        //GET Admin/Users
        //GET Admin/Users/Index
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public ActionResult Index() {
            var model = new UsersViewModel {
                Users = _usersService.GetUsers()
            };
            return View(model);
        }
    
        //GET Admin/Users/User/1
        [HttpGet]
        [Route("User/{id:long}")]
        public ActionResult GetUser(long id) {
            var model = new UserViewModel {
                User = _usersService.GetUser(id),
                Roles = _rolesService.GetRoleDropdown()
            };
    
            return View("User");
        }
    
        //POST Admin/Users/User
        [HttpPost]
        [Route("User")]
        public ActionResult GetUser(UserViewModel model) {
            if (ModelState.IsValid) {
                _usersService.UpdateUserRoles(model.User);
                return RedirectToAction("Index");
            }
    
            return View("User", model);
        }
    }
