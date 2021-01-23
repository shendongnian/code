    // make the base query private   
    private IQueryable<User> GetAllUsersQuery()
    {
        return _dataContext.Users.Where(element => !element.Deleted);
    }
    public IEnumerable<User> GetAllUsers()
    {
        return GetAllUsersQuery().AsEnumerable();
    }
    
    public User GetUserById(string userName)
    {
        return GetAllUsersQuery().FirstOrDefault(elt => elt.UserName.Equals(userName));
    }
