    private async Task<SignInStatus> SignIn(User user, bool isPersistent)
    {
        await SignInAsync(user, isPersistent);
        return SignInStatus.Success;
    }
    public async Task SignInAsync(User user, bool isPersistent)
    {
        var userIdentity = await user.GenerateUserIdentityAsync(UserManager);
        AuthenticationManager.SignIn(
           new AuthenticationProperties
            {
               IsPersistent = isPersistent
            },
            userIdentity
        );
    }
