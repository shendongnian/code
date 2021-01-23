    private async Task CreateRoles(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        // First, Creating User role as each role in User Manager  
        List<IdentityRole> roles = new List<IdentityRole>();
        roles.Add(new IdentityRole {Name = "Admin", NormalizedName = "ADMINISTRATOR"});
        roles.Add(new IdentityRole { Name = "Member", NormalizedName = "MEMBER" });
        roles.Add(new IdentityRole { Name = "Librarian", NormalizedName = "LIBRARIAN" });
        roles.Add(new IdentityRole { Name = "Borrower", NormalizedName = "BORROWER" });
        roles.Add(new IdentityRole { Name = "Reader", NormalizedName = "READER" });
       //Then, the machine added Default User as the Admin user role
        foreach (var role in roles)
        {
            var roleExit = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExit)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
        await CreateUser(context, userManager)
        }
    }
    private async Task CreateUser(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        var adminUser = await userManager.FindByEmailAsync("alpha@lms.com");
        if (adminUser != null)
        {
            if (!(await userManager.IsInRoleAsync(adminUser.Id, "Admin")))
                userManager.AddToRoleAsync(adminUser.UserName, "Admin");
        }
        else
        {
            var newAdmin = new ApplicationUser()
            {
                UserName = "TrueMan",
                Email = "alpha@lms.com",
            };
            await userManager.CreateAsync(newAdmin, "Alpha@Mega");
            await userManager.AddToRoleAsync(newAdmin.userName, "Admin");
        }
    }
