    public ActionResult UserList()
    {
        var context = new ApplicationDbContext();
        var users = from u in context.Users
            where u.Roles.Any(r => r.Role.Name == "Desired role")
            select u;
    
        return View(users);
    }
