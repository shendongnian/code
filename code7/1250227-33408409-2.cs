    public ActionResult RoleAddToUser(string UserName, string RoleName)
    {
       var context = new ApplicationDbContext();
       ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        var account = new AccountController();
     
       // var user = new ApplicationUser { UserName = UserName, Email = UserName };
        //var result = await UserManager.CreateAsync(user, model.Password);
    
        var roleStore = new RoleStore<IdentityRole>(context);
        var roleManager = new RoleManager<IdentityRole>(roleStore);
        var userStore = new UserStore<ApplicationUser>(context);
        var userManager = new UserManager<ApplicationUser>(userStore);     
     
       userManager.AddToRole(user.Id, RoleName);
    
        ViewBag.ResultMessage = "Role created successfully !";
