    public bool IsInAnyRole(RoleEnum userRoles)
    {
        bool ok = false;
        if (userRoles.HasFlag(RoleEnum.Administrator))
        {
           ok |= IsInRole("Administrator");
        }
        if (userRoles.HasFlag(RoleEnum.Moderator))
        {
           ok |= IsInRole("Moderator");
        }
        if (userRoles.HasFlag(RoleEnum.User))
        {
           ok |= IsInRole("User");
        }
        if (userRoles.HasFlag(RoleEnum.Guest))
        {
           ok |= IsInRole("Guest");
        }
        return ok;
    }
