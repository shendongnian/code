     if (!Request.IsAuthenticated)
            {                
                // To execute a policy, you simply need to trigger an OWIN challenge.
                // You can indicate which policy to use by adding it to the AuthenticationProperties using the
                // PolicyKey provided.
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties()
                    {
                        RedirectUri = "/",
                    },
                    appConfiguration.B2CSignInPolicyId);
            }
