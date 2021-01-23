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
