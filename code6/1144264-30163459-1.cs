    // Get the identity framework authentication manager
    var authManager = Request.GetOwinContext().Authentication;
    // Get the identity framework role manager
    var roleManager = Request.GetOwinContext().Get<ApplicationRoleManager>();
    // Get the identity framework user manager
    var userManager = Request.GetOwinContext().Get<ApplicationUserManager>();
