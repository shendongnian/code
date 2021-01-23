    var result = DataContext.Role.Where(role => role.Compulsory == true )
                    .Include(gl => gl.RoleUser)
                    .Select(x => new
                    {
                        role = x,
                        roleUsers= x.RoleUser.Where(g => g.Id == 1),
                    }).ToList();
