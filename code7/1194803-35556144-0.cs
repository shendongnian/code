    // db is of type DbContext or IdentityDbContext
    var userManager = new UserManager(new UserStore(db));
    var dataProtectionProvider = new DpapiDataProtectionProvider("Test");
    userManager.UserTokenProvider = new DataProtectorTokenProvider<User, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
    var user = await UserManager.FindByEmailAsync(model.Email);//Find user by email entered
    //rest of the code
