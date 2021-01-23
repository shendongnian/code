public class UsersController : Controller {
    public async Task Index() {
        var allUsers = await db.Users.ToListAsync();
        var users = allUsers.Select(u => new UsersViewModel {User = u, Roles = String.Join(",", db.Roles.Where(role => role.Users.Any(user => user.UserId == u.Id)).Select(r => r.Name))}).ToList();
        return View(users);
    }
}
