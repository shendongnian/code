    public bool HasPermission(string _permission)
    {
        return UserRoles.Any(r => r.Permissions
                  .Any(p => p.Name == _permission));
    }
