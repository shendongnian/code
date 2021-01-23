        public async Task SignInAsync(IAuthenticationManager authenticationManager, ApplicationUser applicationUser, bool isPersistent)
        {
            authenticationManager.SignOut(
                DefaultAuthenticationTypes.ExternalCookie,
                DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.TwoFactorCookie,
                DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie,
                DefaultAuthenticationTypes.ExternalBearer);
            var identity = await this.CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Email, applicationUser.Email));
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
