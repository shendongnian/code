    // Create manager
     var manager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(
            new ApplicationDbContext()))
    
    // Find user
    var user = manager.FindById(User.Identity.GetUserId());
    var accountId = user.AccountId;
