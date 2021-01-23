    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    // First, Creating User role as each role in User Manager  
    List<IdentityRole> roles = new List<IdentityRole>();
    roles.Add(new IdentityRole {Name = "Admin", NormalizedName = "ADMINISTRATOR"});
    roles.Add(new IdentityRole { Name = "Member", NormalizedName = "MEMBER" });
    roles.Add(new IdentityRole { Name = "Librarian", NormalizedName = "LIBRARIAN" });
    roles.Add(new IdentityRole { Name = "Borrower", NormalizedName = "BORROWER" });
    roles.Add(new IdentityRole { Name = "Reader", NormalizedName = "READER" });
