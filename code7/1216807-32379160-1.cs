    public IEnumerable<object> GetAll()
    {
        var Users = Ctx.SystemUsers.ToList().Select(u => new
        {
            User = u.Username,
            Admin = u.Type
        });
        return Users.ToList();
    }
