    using(YourDbContext context = new YourDbContext())
    {
        var query = context.Users.Include(user => user.Connections);
        // Do stuff with query
    }
    
