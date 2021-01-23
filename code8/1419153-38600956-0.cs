    // Create a new User object using (all of the required) properties of the 
    // new User you have just created via the Register method
    ZivoyDbContext.Users.Add(new ApplicationUser
                    {
                        UserName = user.UserName,
                        PasswordHash = user.Password,
                        Email = user.Email 
                    }
    );
