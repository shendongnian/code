    public Task<IdentityResult> ChangePassword(ApplicationUser user, string newPassword)
    {
         var store = Store as IUserPasswordStore<ApplicationUser, string>;
         return UpdatePassword(store, user, newPassword);
    }
