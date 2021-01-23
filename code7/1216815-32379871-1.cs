    Ctx.SystemUsers.ToList().Select(u => new SystemUserDTO
    {
        Username = u.Username,
        Type = u.Type
    });
