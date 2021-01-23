    public class UsersController : Controller {
        public async Task Index() {
            var users = allUsers.Select(u => new UserViewModel {UserName = u.UserName, Roles = String.Join(",", u.Roles.Select(r => r.RoleName))}).ToList();
            return View(users);
        }
    }
