    public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool rememberMe, bool shouldLockout)
        {
            var user = UserManager.FindByEmailAsync(userName).Result;
            if ((user.IsEnabled.HasValue && !user.IsEnabled.Value) || !user.IsEnabled.HasValue)
            {
                return Task.FromResult<SignInStatus>(SignInStatus.LockedOut);
            }
            return base.PasswordSignInAsync(userName, password, rememberMe, shouldLockout);
        }
