    [NonAction]
    public async Task<ApplicationUser> getCurrentUser(string userid)
    {
        var user = (ApplicationUser)await UserManager.FindByIdAsync(userid);
        return user;
    }
    
    [NonAction]
    public async Task<int> editCurrentUser(ApplicationUser user)
    {
        await UserManager.UpdateAsync(user);
        return 1;
    }
