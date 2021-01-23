	public static void InitializeIdentityForEF(IdentityDbContext db)
	{
		var userManager = new ApplicationUserManager(new ApplicationUserStore(db));
		var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(db));
    }
