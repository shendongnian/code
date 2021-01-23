    var users = context.Users
            .Select(u => new UserModel 
            {
                Name = u.Name,
                Roles = u.Roles.Select(r => r.Id)
            })
            .AsEnumerable() //Add this 
            .Union(context.TempUsers
            .Select(u => new UserModel 
            {
                Name = u.Name,
            }))
    .ToList();
