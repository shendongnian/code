        protected override void Seed( MySqlInitializer context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext("DefaultConnection")));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext("DefaultConnection")));
            const string name = "admin@example.com";
            const string password = "Password";
            const string roleName = "Admin";
            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                roleManager.Create(role);
            }
            context.SaveChanges();
            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
            }
            context.SaveChanges();
            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                userManager.AddToRole(user.Id, role.Name);
            }
            context.SaveChanges();
        }
