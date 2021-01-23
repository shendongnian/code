    ApplicationDbContext context = new ApplicationDbContext();
    IdentityResult identityRoleResult;
    IdentityResult identityUserResult;
    var roleStore = new RoleStore<IdentityRole>(context);
    var roleMgr = new RoleManager<IdentityRole>(roleStore);
    if (!roleMgr.RoleExists("SuperAdmin"))
    {
        identityRoleResult = roleMgr.Create(new IdentityRole { Name = "SuperAdmin" });
    }
    var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    var appUser = new ApplicationUser
    {
        UserName = "SuperAdminUser@wingtiptoys.com",
        Email = "SuperAdminUser@wingtiptoys.com"
    };
    identityUserResult = userMgr.Create(appUser, "Pa$$word1");
    if (!userMgr.IsInRole(userMgr.FindByEmail("SuperAdminUser@xyz.com").Id, "SuperAdmin"))
    {
        identityUserResult = userMgr.AddToRole(userMgr.FindByEmail("SuperAdminUser@wingtiptoys.com").Id, "SuperAdmin");
    }
