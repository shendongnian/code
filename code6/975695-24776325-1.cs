    var roles = roleService
        .GetOrderedRoles()
        .Select(role =>
                new RoleViewModel
                {
                    RoleName = role.Name,
                    Description = role.Description,
                    ApplicationArea = role.Area.Application.Name
                        + "/" + role.Area.Name,
                    GroupsUsingThisRole = role.RoleGroupMappings
                        .Select(rgm => rgm.Group.Name).ToList()
                })
        .ToList();
