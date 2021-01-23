    List<List<Permission>> disabledPermissions = new List<List<Permission>>();
    foreach (List<Permission> permissions in permisionLists)
    {
        bool HasAnyPermissionDisabled = false;
        foreach (Permission p in permissions)
        {
            if (!p.HasPermission)
            {
                HasAnyPermissionDisabled = true;
                break;
            }
        }
        if (!HasAnyPermissionDisabled)
            disabledPermissions.Add(permissions);
    }
