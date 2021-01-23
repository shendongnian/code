    /* Create Roles */
    IEnumerable<UserRole> allRoles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>();
    foreach (UserRole role in allRoles)
    {
         if (!await roleManager.RoleExistsAsync(role.ToString()))
         {
                    await roleManager.CreateAsync(new IdentityRole { 
                              Name = role.ToString(), 
                              NormalizedName = role.ToString().ToUpper() 
                            });
         }
    }
    
