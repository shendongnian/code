     var roles = database.RolesRepository.Get().ToArray();
     var answers = roles.Where(a => a.isDeleted == false).Select(r => new {
            Name = r.Name,
            Description = r.Description,
            ModuleWisePrivileges = string.Join(", ", (r.ModulePrivilegeIds.Split(',')
                                    .Select(x => database.PrivilegesRepository.Get(x).FirstOrDefault())
                                    .ToArray()),
            FunctionWisePrivileges = string.Join(", ", (r.FunctionPrivilegeIds.Split(',')
                                      .Select(x => database.PrivilegesRepository.Get(x).FirstOrDefault())
                                      .ToArray()),
            Active = r.Active
        }
