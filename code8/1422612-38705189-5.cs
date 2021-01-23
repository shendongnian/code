    public IEnumerable<User> GetAllUsers()
    {
        return userMapping.Values
            .Select(u => new User { xCoor = u.xCoor, yCoor = u.yCoor });
    }
