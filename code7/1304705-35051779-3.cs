    return context.Users.Select(u => new UserViewModel
    {
        Email = u.Email,
        UserId = u.Id,
        Roles = String.Join("/", u.Roles.Select(ru => ctx.Roles.First(rr => rr.Id == ru.RoleId).Name.First()))
    }).ToList();
