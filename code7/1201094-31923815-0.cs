    [AuthorizeLevel(AuthorizationLevel.User)]
    public IQueryable<MyModel> GetAllMyInfo()
    {
        // Get the current user
        var currentUser = User as ServiceUser;
        var ownerId = currentUser.Id;
        return Query().Where(s => s.OwnerId == ownerId); 
    }
