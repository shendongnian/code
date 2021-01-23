    public IEnumerable<object> GetAll()
    {
        var Users = Ctx.SystemUsers.ToList().Select(u => new
        {
            Username = u.Username,
            Type = u.Type
        });
        return Users.ToList();
    }
