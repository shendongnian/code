    return db.UserProfiles
             .Include(up => up.UserRoles)
             .Include("UserRoles.Roles") // <-- Added further include
             .Select(u => new UserModel() {
                                ID = u.ID,
                                Username = u.UserName,
                                IsLockedOut = u.IsLockedOut,
                                LastLoginDate = u.LastLoginDate,
                                // Modified this to use joining table
                                UserRoles = u.UserRoles 
                                             .Select(ur => new RoleModel() {
                                                            Name = ur.Role.Name,
                                                            ID = ur.RoleID
                                                          })
                          })
             .ToList();
