    var user = new AspNetUser
    { 
        Id = Guid.NewGuid().ToString(),
        UserName = username
    };
    var userManager = new UserManager<AspNetUser>();
    userManager.Create(user, "password");
    userManager.AddToRole(user.Id, "RoleName");
