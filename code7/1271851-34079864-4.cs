    public class UsersController : Controller {
        public async Task Index() {
            var users = allUsers.Select(u => new UserViewModel {UserName = u.UserName, Roles = String.Join(",", u.UserRoles.Where(userRole => u.Roles.Select(r => r.RoleId).Contains(userRole.Id)).Select(userRole => userRole.Name)}).ToList();
            return View(users);
        }
    }
