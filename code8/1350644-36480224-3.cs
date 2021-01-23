        RoleBasedSecurity.Models.ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser au = context.Users.First(u => u.UserName == "admin@admin.com");
        foreach (IdentityUserRole role in au.Roles)
        {
            string name = role.RoleId;
            string RoleName = context.Roles.First(r => r.Id == role.RoleId).Name;
        }
