    bool isInRole(Roles currentRole, Roles expectedRole)
    {
        return currentRole >= expectedRole;
    }
    isInRole(Roles.Admin, Roles.Admin); // true
    isInRole(Roles.Edit, Roles.Admin); // false
    isInRole(Roles.Edit, Roles.Edit); // true
    isInRole(Roles.Edit, Roles.View); // true
