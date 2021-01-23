                    //To Log In
                FederatedAuthentication.WSFederationAuthenticationModule.RedirectToIdentityProvider("MYSiteIDYouMakeUpHere", "TheUrlToReturnToAfterLoginHere", true);
                //ToLogOut
                var issuer = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration.Issuer;
                var signOutUrl = WSFederationAuthenticationModule.GetFederationPassiveSignOutUrl(issuer, "returnurlhere", null);
                Redirect(signOutUrl);
  
