    var res = db.Users.SelectMany(u => 
                      u.Roles.Select(r =>
                          new {
                            u.UserName,
                            r.RoleName,
                            u.IsActive
                          }
                      )
              );
