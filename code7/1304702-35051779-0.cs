    return context.Users.Select(u => new UserViewModel
    {
        Email = u.Email,
        UserId = u.Id,
        Roles = String.Join("/", u.Roles.Select(r => r.Name.First()));
    }).ToList();
