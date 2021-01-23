      // Write user
      using (var userDbContext = new UserSystemDbContext())
      {
        var user = new User { Name = "User", StringArray = new Collection<string>() { "Bassam1", "Bassam2" } };
        userDbContext.Users.Add(user);
        userDbContext.SaveChanges();
      }
      // Read User 
      using (var userDbContext = new UserSystemDbContext())
      {
        var user = userDbContext.Users.ToList().Last();
        foreach (var userArray in user.StringArray)
        {
          Console.WriteLine(userArray);
        }
      }
