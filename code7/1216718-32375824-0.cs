    context.SystemUsers.Select(u => new SystemUser
    {
        Username = u.Username,
        Type = u.Type
    });
