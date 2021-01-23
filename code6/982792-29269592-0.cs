    context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = "demo",
                        Email = "demo@demo.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PasswordHash = password,
                        PhoneNumber = "111-222-3344",
                        SecurityStamp = Guid.NewGuid().ToString() //THIS IS WHAT I NEEDED
                    });
