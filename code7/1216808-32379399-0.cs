    public IEnumerable<object> GetAll()
    {
        return Ctx.SystemUsers.Select(u => new SystemUser
        {
            Username = u.Username,
            Type = u.Type
        }).ToList();;
    }
