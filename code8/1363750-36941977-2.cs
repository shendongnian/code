        context.Roles.AddOrUpdate(r => r.Name,
            new IdentityRole { Name = "Role1" },
            new IdentityRole { Name = "Role2" },
            new IdentityRole { Name = "Role3" }
            );
        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        UserManager.AddToRole("Put User ID here", "Role1");
