    string userId = userDetails.Id;
    IList<string> assingedRoles = await UserManager.GetRolesAsync(userId);
    if (!assingedRoles.Contains("SuperAdmin") && 
        !assingedRoles.Contains("ReadOnlyAdmin"))
    {
        await UserManager.AddToRoleAsync(userId, "User");
    }
    // UserManager
    private AppUserManager UserManager
    {
        get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
    }
