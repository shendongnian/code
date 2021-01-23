    /// <summary>
    /// Gets all users
    /// </summary>
    /// <param name="includes">Optional parameter for eager loading related entities</param>
    /// <returns>An list of users</returns>
    public IQueryable<User> GetAll(params string[] includes) {
            
        // Get our User DbSet
        var users = base.Users;
            
        // For each include, include in the query
        foreach (var include in includes)
            users = users.Include(include);
        // Return our result
        return users;
    }
