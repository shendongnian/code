    public IQueryable<Models.ApplicationUser> GetUserListQuery(bool IncludeDisabled = false, bool IncludeDeleted = false, bool IncludeEmployees = false )
    {
        IQueryable<Models.ApplicationUser> result = DefaultContext.Users;
        if (!IncludeDisabled)
            result = result.Where(user => user.Enabled);
        if (!IncludeDeleted)
            result = result.Where(user => !user.Deleted);
        if (!IncludeEmployees)
            result = result.Where(user => !user.Roles.Any(role => role.Id == "Employee"));
        return result;
    }
