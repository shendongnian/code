    var user = new ApplicationUser { UserName = "chris", Email = "chris@chris.com" };
    PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
    user.PasswordHash = ph.HashPassword(user, "admin3##"); //More complex password
    manager.CreateAsync(user);
    manager.AddToRoleAsync(user, "admin");
