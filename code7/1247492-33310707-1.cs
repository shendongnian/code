    public override async Task<SignInStatus> PasswordSignInAsync(
        string userName,
        string password,
        bool isPersistent,
        bool shouldLockout)
    {
        // other parts
        
        if (UserManager.SupportsUserPassword
            && await UserManager.CheckPasswordAsync(user, password)
                                .WithCurrentCulture())
        {
            // this method actually do the job
            return await SignInOrTwoFactor(user, isPersistent).WithCurrentCulture();
        }
        // rest of code
    }
