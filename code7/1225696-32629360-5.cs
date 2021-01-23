    var result = session.Query<User>()
                        .Where(c => c.UserName == userName)
                        .FetchMany(c => c.Roles)
                        .ThenFetchMany(o => o.Permissions)
                        .Select(u => new { u.Id, u.UserName })
                        .ToList(); // or FirstOrDefault();
