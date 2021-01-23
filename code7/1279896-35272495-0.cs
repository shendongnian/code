        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();
            db.Database.Migrate();
            //If no role found in the Roles table
            //RoleStore needs using Microsoft.AspNet.Identity.EntityFramework;
            var identityRoleStore = new RoleStore<IdentityRole>(db);
            var identityRoleManager = new RoleManager<IdentityRole>(identityRoleStore, null, null, null, null, null);
                var adminRole = new IdentityRole { Name = "ADMIN" };
            await identityRoleManager.CreateAsync(adminRole);
          
   
                var officerRole = new IdentityRole { Name = "OFFICER" };
            await identityRoleManager.CreateAsync(officerRole);
        
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore, null, null, null, null, null, null, null, null, null);
            var danielUser = new ApplicationUser { UserName = "DANIEL", Email = "DANIEL@EMU.COM" };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
             danielUser.PasswordHash = ph.HashPassword(danielUser, "P@ssw0rd!1"); //More complex password
            await userManager.CreateAsync(danielUser);
            await userManager.AddToRoleAsync(danielUser, "ADMIN");
           
     
               var susanUser = new ApplicationUser { UserName = "SUSAN", Email = "SUSAN@EMU.COM" };
               susanUser.PasswordHash = ph.HashPassword(susanUser, "P@ssw0rd!2"); //More complex password
            await userManager.CreateAsync(susanUser);
            await userManager.AddToRoleAsync(susanUser, "ADMIN");
            
   
                var randyUser = new ApplicationUser { UserName = "RANDY", Email = "RANDY@EMU.COM" };
            randyUser.PasswordHash = ph.HashPassword(randyUser, "P@ssw0rd!3"); //More complex password
            await userManager.CreateAsync(randyUser);
            await userManager.AddToRoleAsync(randyUser, "OFFICER");
        
            var thomasUser = new ApplicationUser { UserName = "THOMAS", Email = "THOMAS@EMU.COM" };
          thomasUser.PasswordHash = ph.HashPassword(thomasUser, "P@ssw0rd!4"); //More complex password
            await userManager.CreateAsync(thomasUser);
            await userManager.AddToRoleAsync(thomasUser, "OFFICER");
            var benUser = new ApplicationUser { UserName = "BEN", Email = "BEN@EMU.COM" };
            benUser.PasswordHash = ph.HashPassword(benUser, "P@ssw0rd!5"); //More complex password
            await userManager.CreateAsync(benUser);
            await userManager.AddToRoleAsync(benUser, "OFFICER");
            
              if (db.Courses.FirstOrDefault() == null)
              {
                  Course ditCourse = new Course()
                  {
                      CourseAbbreviation = "DIT",
                      CourseName = "DIPLOMA IN INFORMATION TECHNOLOGY",
                      CreatedById = randyUser.Id,
                      UpdatedById = thomasUser.Id
                  };
                  db.Courses.Add(ditCourse);
                  Course dbitCourse = new Course()
                  {
                      CourseAbbreviation = "DIPLOMA IN BUSINESS INFORMATION TECHNOLOGY",
                      CourseName = "DBIT",
                      CreatedById = thomasUser.Id,
                      UpdatedById = thomasUser.Id
                  };
                  db.Courses.Add(dbitCourse);
                  Course dismCourse = new Course()
                  {
                      CourseAbbreviation = "DISM",
                      CourseName = "DIPLOMA IN INFOCOMM SECURITY MANAGEMENT",
                      CreatedById = thomasUser.Id,
                      UpdatedById = benUser.Id
                  };
                  db.Courses.Add(dismCourse);
              }
             
            db.SaveChanges();
            // TODO: Add seed logic here
        }
