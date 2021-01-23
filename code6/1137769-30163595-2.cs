    #region UserAllCSPermissionBasedAuthFilter
    kernel.BindFilter<UserAllCSPermissionBasedAuthFilter>(FilterScope.Action, 0)
        .WhenActionMethodHas<UserAllCSPermissionBasedAuthFilter>()
        .WithConstructorArgumentFromActionAttribute<UserAllCSPermissionBasedAuthFilter>("permissionEnums", att => att.PermissionEnums);
    kernel.BindFilter<UserAllCSPermissionBasedAuthFilter>(FilterScope.Controller, 0)
        .WhenActionMethodHas<UserAllCSPermissionBasedAuthFilter>()
        .WithConstructorArgumentFromControllerAttribute<UserAllCSPermissionBasedAuthFilter>("permissionEnums", att => att.PermissionEnums);
    #endregion
