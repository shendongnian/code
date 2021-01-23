    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
    {
        var manager = new ApplicationUserManager(
            new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()) 
                 { AutoSaveChanges = false });
        // rest of codes
    }
