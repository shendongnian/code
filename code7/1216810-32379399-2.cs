    public IEnumerable<SystemUser> GetAll()
    {
        return Ctx.SystemUsers.Select(u => new SystemUser()
        {
            Username = u.Username,
            Type = u.Type
        }).ToList();
    }
