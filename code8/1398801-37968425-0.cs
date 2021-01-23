    var user = context.Users.Where(u => u.UserName == "Admin");
    if (user == null))
    {
        user = new User { UserName = "Admin", Age = 115 };
        var adminresult = manager.Create(user, "12345678");
    
        if (adminresult.Succeeded)
            manager.AddToRole(user.Id, "Admin");
    }
    else
    {
        user.Age = 20;
    }
    context.SaveChanges()
