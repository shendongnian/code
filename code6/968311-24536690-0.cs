    return db.UserProfiles.Include(up => up.UserRoles)
                          .Select(u => new UserModel() {
                                             ID = u.ID,
                                             Username = u.UserName,
                                             IsLockedOut = u.IsLockedOut,
                                             LastLoginDate = u.LastLoginDate,
                                             UserRoles = u.Roles
                                                          .Select(r => new RoleModel() {
                                                                    Name = r.Name,
                                                                    ID = r.ID )
                                 })
                          .ToList();)
