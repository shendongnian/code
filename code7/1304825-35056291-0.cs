    [Route("getUsers")]
    // GET: User
    public IQueryable<object> getUsers()
    {
        var users = DbContext.Users.Select( u => new {Id = u.Id, Fullname = u.Fullname});
        return users;
    }
