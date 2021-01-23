    1    public void AddOrganisationAdmin()
    2    {
    3        
    4        String OrganisationName = Request["OrganisationName"];
    5        Debug.Print(OrganisationName);
    6        RegisterViewModel model = new RegisterViewModel();
    7        model.Email = "admin@" + OrganisationName + ".com";
    8        model.Organisation = OrganisationName;
    9        model.Password = "adminPassword!1";
    10       model.ConfirmPassword = "adminPassword!1";
    11       model.Role = "Organisation Admin";
    12       Promato.Models.ApplicationDbContext dbcontext = new Promato.Models.ApplicationDbContext();
    13        
    14       var user = new ApplicationUser() { UserName = model.Email, Email = model.Email, Organisation = model.Organisation, Role = model.Role };
    15       user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
    16       user.SecurityStamp = Guid.NewGuid().ToString();
    17       dbcontext.Users.Add(user);
    18       dbcontext.SaveChanges();
    19   }
