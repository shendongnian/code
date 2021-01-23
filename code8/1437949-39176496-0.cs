    [RouteArea("Admin")]
    [RoutePrefix("Users")]
    public class UsersController : Controller {
    
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
