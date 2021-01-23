    protected override void Seed(MyDbContext context)
    {
        if (!context.Users.Any(u => u.Username == "administrator"))
        {
            var user = new User { Username = "administrator", PasswordHash = "hashed password" };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
