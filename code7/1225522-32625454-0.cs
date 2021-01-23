    var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            
            if (!context.Users.Any(t => t.UserName == "admin@Konek.com"))
            {
                var user = new ApplicationUser { UserName = "admin@Konek.com", Email = "admin@Konek.com" };
                userManager.Create(user, "Password1!");
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Receptionist" });
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Security" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
                Employee admingEmployee = new Employee
                {
                    Age=25,
                    Citizenship="Filipino",
                    CivilStatus=CivilStatus.Single,
                    DateOfBirth=DateTime.Now,
                    EmailAddress="admin@Konek.com",
                    FirstName="Admin",
                    Gender=Gender.Male,
                    HomeAddress="None",
                    LandLine="531-5555",
                    LastName="Administrator",
                    MiddleName="admin",
                    MobileNumber="09275225222",
                    Photo = "*******",
                    PlaceofBirth="*****",
                    Password = "********",
                    Role=Role.Admin
                };
                context.Employees.Add(admingEmployee);
                context.SaveChanges();
