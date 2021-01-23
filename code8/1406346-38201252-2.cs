    public List<User> GetPublicUsers()
    {
        var existingUsers = dbContext.Users
            .Where(u => u.IsPublic);
    
        var result = new List<User>();
        foreach(var existingUser in existingUsers)
        {
            result.Add(new User { Id = existingUser.Id, ...}));
        }
        return result;
    }
