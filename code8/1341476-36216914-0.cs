    //checking is role exists
    var roleExist = context.Roles.Any(x => x.Name == "MyRole");
    //no existing users with that role
    var withRoles = context.User2Roles.Where(x => x.Role.Name == "MyRole").Any();
    //Add or update admin user
    var admin = context.Users.AddOrUpdate(x => x.Email, new User { EMail = "Admin" });
    //other stuff, it is only example correct it on your own!!!
    var role = context.Roles.Where(x => x.Name == "MyRole").First();
    context.User2Roles.Add(new User2Roles{ User = admin, Role = role });
    context.SaveChanges();
