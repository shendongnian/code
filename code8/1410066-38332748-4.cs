    var query=context.TempUsers
              .Select(u => new TempUser
              {
                Name = u.Name,
              })
              .Union(context.Users
              .Select(u => new UserModel 
              {
                Name = u.Name,
                Roles = u.Roles.Select(r => r.Id)
              }).OfType<TempUser>())
              .ToList();
