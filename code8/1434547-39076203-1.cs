    var user = new AspNetUser
    { 
        Id = Guid.NewGuid().ToString(),
        UserName = username
    };
    db.AspNetUsers.Add(user);
    var role = db.AspNetRoles.Single(r => r.Name = "RoleName");
    user.Roles.Add(role);
    db.SaveChanges();
