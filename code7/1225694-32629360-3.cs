    var result = session.Query<User>()
                        .Where(c => c.UserName == userName)
                        .FetchMany(c => c.Roles)
                        .ThenFetchMany(o => o.Permissions)
                        .ToList();
    // and you could loop it:
    foreach (var user in result)
    {
          // code...
    }
