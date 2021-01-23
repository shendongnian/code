    public User GetUser(int userId)
    {
        var user = _user.GetOrAdd(userId, GetUserFromDb);
        if (user == null) _user.TryRemove(userId, out user);    
    }
