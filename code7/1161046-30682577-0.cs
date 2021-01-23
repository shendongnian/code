    from compUsr in Repository.All<CompanyUser>()
    join usr in Repository.All<User>() on compUsr.UserId equals usr.Id
    join usrRole in Repository.All<UserRole>() on usr.Id equals usrRole.UserId
    join role in Repository.All<Role>() on usrRoles.RoleId equals role.Id
    group new { usr, role } by usr into grp
                        select new
                        {
                            Id = grp.Key.Id,
                            Email = grp.Key.Email,
                            Roles = grp.Select(r => new RoleDTO()
                            {
                                Id = r.role.Id
                            })
                        };
