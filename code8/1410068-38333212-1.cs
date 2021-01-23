    var users = context.Users
            .Select(u => new UserModel 
            {
                Name = u.Name,
                Roles = u.Roles.Select(r => r.Id)
            })
        .Union(context.TempUsers
            .Select(u => new TempUserModel 
            {
                Name = u.Name
            }))
        .ToList();
