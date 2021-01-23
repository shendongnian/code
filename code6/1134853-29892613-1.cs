    public ActionResult UserList(string roleName)
    {
        var context = new ApplicationDbContext();
        var users = from u in context.Users
            where u.Roles.Any(r => r.Role.Name == roleName)
            select u;
    
        ViewBag.RoleName = roleName;
        return View(users);
    }
