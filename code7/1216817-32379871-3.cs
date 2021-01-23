    Ctx.SystemUsers.ToList().Select(u => new SystemUserViewModel
    {
        Username = u.Username,
        Type = u.Type
    });
