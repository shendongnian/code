    from usr in context.Users // or Repository.All<User>()
    select new UserDto
    {
        Id = usr.Id,
        Email = usr.Email,
        Roles = usr.UserRoles.Select(ur => ur.Roles)
                   .Select(r => new RoleDTO()
                                {
                                    Id = r.Id
                                }
    }
