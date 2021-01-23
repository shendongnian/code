    var appRoleAssignment = new AppRoleAssignment()
    {
        ResourceId = Guid.Parse(principal.ObjectId),
        PrincipalId = Guid.Parse(user.ObjectId),
        Id = Guid.Parse(roleId)
    };
    user.AppRoleAssignments.Add(appRoleAssignment);
    await user.UpdateAsync();
