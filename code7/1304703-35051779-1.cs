    return context.Users.Select(u => new UserViewModel
    {
        Email = u.Email,
        UserId = u.Id,
        Roles = String.Join("/", UserManager.GetRolesAsync(u.Id).Select(r => r.First()));
    }).ToList();
