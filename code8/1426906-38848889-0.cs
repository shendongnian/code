    public static string GetCurrentUserEmail()
            {
                var userEmail = string.Empty;
                var claimIdentity = new ClaimsIdentity(Thread.CurrentPrincipal.Identity);
                var userEmailClaim = claimIdentity.Claims.FirstOrDefault(x => x.Type == IdentityConstants.EmailClaimType);
    
                if (userEmailClaim != null)
                {
                    userEmail = userEmailClaim.Value;
                }
                return userEmail;
            }
