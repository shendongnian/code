    var roles = database.RolesRepository.Get().ToArray();
    var answers = roles.Select(r => new {
                    Name = r.Name,
                    Description = r.Description,
                    ModuleWisePrivileges = r.ModulePrivilegeIds.Split(',')
                                            .Select(x => database.PrivilegesRepository.Get(x))
                                            .ToArray(),
                    FunctionWisePrivileges = r.FunctionPrivilegeIds.Split(',')
                                              .Select(x => database.PrivilegesRepository
                                                                   .Get(x))
                                              .ToArray(),
                    Active = r.Active
                }
