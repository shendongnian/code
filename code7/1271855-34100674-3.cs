public class UsersController : Controller {
    public async Task Index() {
        var allUsers = await db.Users.ToListAsync();
        // set all roles to a variable, so that we don't hit the database for every user iteration
        // is this true?
        var allRoles = await db.Roles.ToListAsync();
        var users = allUsers.Select(u => new UsersViewModel {User = u, Roles = String.Join(",", allRoles.Where(role => role.Users.Any(user => user.UserId == u.Id)).Select(r => r.Name))}).ToList();
        return View(users);
    }
}
