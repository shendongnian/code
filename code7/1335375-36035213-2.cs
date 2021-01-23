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
    //    var user = await UserManager.FindByIdAsync("7bd66984-a290-4442-a9f8-5659e01b0c06");
            //    await UserManager.AddToRoleAsync(user, "Admin");
    }
