    permisionLists.ForEach(permissions => permissions.Where(p => !p.HasPermission).ToList().ForEach(permission =>
    {
        if (!permisionLists.Where(permissionList => permissionList.Where(p => p.Id == permission.Id).FirstOrDefault().HasPermission).Any())
        {
            disabledPermissions.Add(permission);
        }
    }));
