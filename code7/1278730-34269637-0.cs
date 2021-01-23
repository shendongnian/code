    public void RegisterDealer(RegisterAdministrator model)
    {
        ApplicationDbContext dbc = new ApplicationDbContext();
        var user = new ApplicationUser { UserName = model.administratorName, Email = model.administratorEmail, AccountNumber = model.AccountNumber, LoginUserName = model.LoginUserName };
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.LockoutEnabled = true;
        user.AccountNumber = "1";
        user.IsActive = true;
        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbc));
        UserManager.Create(user, "PasswordWithoutHash");
        dbc.SaveChanges();
        // Retrieve user to add to role
        var newUser = dbc.Users.FirstOrDefault(x => x.Email == user.Email)       
        
        // If user created, add to the role
        if(newUser != null)
        {
            userManager.AddToRole(newUser.Id, "RoleName");
            dbc.SaveChanges();
        }
        //UserManager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + id + "\">here</a>");
    }
