    public IEnumerable<object> GetAll()
    {
        return Ctx.SystemUsers.Select(u => new 
        {
            Username = u.Username,
            Type = u.Type
        }).ToList();
    }
