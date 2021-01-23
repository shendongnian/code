    var dbUser = new User 
    { 
        Firstname = model.FirstName, 
        Lastname = model.LastName, 
        Email = model.UserName 
    };
    var appUser = new ApplicationUser(model.UserName);
    appUser.UserInfo = dbUser;
    try
    {
       var result = await UserManager.CreateAsync(appUser, model.Password);
    }
    catch (Exception e)
    {
       // show error or whatever
    }
