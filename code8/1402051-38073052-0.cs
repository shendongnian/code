    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>(); 
    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>(); 
    var user = new ApplicationUser() { UserName = name, Email = email }; 
    IdentityResult result = manager.Create(user, password); 
    if (result.Succeeded)
