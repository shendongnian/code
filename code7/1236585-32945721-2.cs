    var roles = database.RolesRepository.Get().ToArray();
    var privileges = database.PrivilegesRepository.Get().ToDictionary(x => x.Id, x => x);
    var answers = roles.Select(r => new {
                    Name = r.Name,
                    Description = r.Description,
                    ModuleWisePrivileges = r.ModulePrivilegeIds.Split(',')
                                            .Select(x => privileges[x])
                                            .ToArray(),
                    FunctionWisePrivileges = r.FunctionPrivilegeIds.Split(',')
                                              .Select(x => privileges[x])
                                              .ToArray(),
                    Active = r.Active
                }
