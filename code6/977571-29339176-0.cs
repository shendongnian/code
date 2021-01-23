    protected override void Seed(MyProject.Dal.Context.MyProjectDbContext context)
        {
            context.Users.AddOrUpdate(u => u.Id, new Core.Entities.ApplicationUser{
                 Id = "1",
                 UserName = "foo@a.com",
                 Email = "foo@a.com",
                 PasswordHash = new PasswordHasher().HashPassword("@edulopezTest"),
                 SecurityStamp = string.Empty,
                 Names = "Test",
                 LastNames = "Admin",
                 BirthDate = DateTime.Now,
             });
           var  RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
           if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
           {
               var role = new IdentityRole { Name = "SuperAdmin" };
               RoleManager.Create(role);
           }
           //**********************************************************
           //THIS IS ANOTHER WAY TO ADD THE ROLES. IT GIVE SAME RESULTS
           //**********************************************************
           //context.Roles.AddOrUpdate(r => r.Name,
           //    new IdentityRole { Name = "SuperAdmin" }    // 1
           //   , new IdentityRole { Name = "Admin" }         // 2
           //   );  
        var userManager = new UserManager<Core.Entities.ApplicationUser>(new UserStore<Core.Entities.ApplicationUser>(context));          
        userManager.AddToRole("1", "SuperAdmin");
        }
