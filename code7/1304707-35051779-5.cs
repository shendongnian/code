    return context.Users.Select(u => new UserViewModel
    {
        Email = u.Email,
        UserId = u.Id,
        Roles = String.Join("/", context.Roles.Where(r => r.Users.Any(u2 => u2.UserId == u.Id)).Select(r => r.Name.First()))
    }).ToList();
