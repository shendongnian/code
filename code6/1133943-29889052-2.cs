    public void ExternalLoginCallback(HttpContext context, IAuthenticationManager authManager)
        {
            var loginInfo = authManager.GetExternalLoginInfo();
            if (loginInfo == null)
            {
                throw new System.Security.SecurityException("Failed to login");
            }
    
            var LoginProvider = loginInfo.Login.LoginProvider;
            var ExternalLoginConfirmation = loginInfo.DefaultUserName;
    
            var externalIdentity = authManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
            var emailClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var email = emailClaim.Value;
    
            var pictureClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type.Equals("picture"));
            var pictureUrl = pictureClaim.Value;
    
            LogInByEmail(context, email, LoginProvider); //redirects to my method of adding claimed user as logged in, you will use yours.
        }
