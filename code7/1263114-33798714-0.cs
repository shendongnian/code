using (var db = new ApplicationDbContext())
{
    var user1 = new ApplicationUser { Email = "user1@test.com", UserName = "User #1"};
    var user2 = new ApplicationUser { Email = "user2@test.com", UserName = "User #2 - No Roles" };
    var role1 = new IdentityRole("SomeRole");
    db.Users.Add(user1);
    db.Users.Add(user2);
    db.Roles.Add(role1);
    db.SaveChanges();
    user1.Roles.Add(new IdentityUserRole { RoleId = role1.Id });
    db.SaveChanges();
    var usersInRole = db.Users.Where(u =>
        u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
        role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("SomeRole"))).ToList();}
