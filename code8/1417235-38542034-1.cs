    var user = new ApplicationUser {
        UserName = "new_user",
        Email = "user@gmail.com"
    };
    string password = "secret";
    using (var db = new ApplicationDbContext())
    {
        var store = new UserStore<ApplicationUser>(db);
        var manager = new UserManager<ApplicationUser, string>(store);
        var result = manager.Create(user, password);
        if (!result.Succeeded)
            throw new ApplicationException("Unable to create a user.");
        result = manager.AddToRole(user.Id, "Administrator");
        if (!result.Succeeded)
            throw new ApplicationException("Unable to add user to a role.");
    }
