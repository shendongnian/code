    //checking is role exists
    var roleExist = context.Roles.Any(x => x.Name == "MyRole");
    //no existing users with that role
    var withRoles = context.User2Roles.Where(x => x.Role.Name == "MyRole").Any();
    //Add or update admin user
    context.Users.AddOrUpdate(x => x.Email, new User { EMail = "Admin" });
    //get admin and role after creating them, if it needed(not shown)
    var role = context.Roles.Where(x => x.Name == "MyRole").First();
    var admin = context.Users.Where(x => x.Email == "Admin").First();
    //add role to admin if role not already was linked to him, checking code not shown
    context.User2Roles.Add(new User2Roles{ User = admin, Role = role });
    context.SaveChanges();
