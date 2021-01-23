    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        EducationArmRequirement requirement)
    {
        if (await IsEducationGroup(context))
        {
            context.Succeed(requirement);
        }
    }
    
    protected async Task<bool> IsEducationGroup(AuthorizationHandlerContext context)
    {
        var userId = context.User.Identity.Name;
    
        ApplicationUser u = await _userManager.FindByNameAsync(userId);
    
        return u.Group == 3 || u.Group == 4;
    }
