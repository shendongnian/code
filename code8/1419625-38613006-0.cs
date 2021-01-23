    public enum Roles
    {
      Developer,
      Manager
     }
    if (!roleManager.RoleExists(Roles.Developer))
    {
        // first we create Admin rool   
        var role = new ApplicationRole();
        role.Name = Roles.Developer;
        role.roleId = RoleId.Developer;
        roleManager.Create(role);
        //Here we create a Admin super user who will maintain the website                  
        var user = new ApplicationUser();
        user.UserName = "ra3iden";
        user.Email = "Email@gmail.com";
        user.FirstName = "Myname";
        user.LastName = "LastName";
        string userPWD = "A@Z200711";
        var chkUser = UserManager.Create(user, userPWD);
        //Add default User to Role Admin   
        if (chkUser.Succeeded)
        {
            var result1 = UserManager.AddToRole(user.Id, Roles.developer);
        }
    }
