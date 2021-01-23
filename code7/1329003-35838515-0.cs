    var facebookAuthenticationOptions = new FacebookAuthenticationOptions()
                {
                    AppId = ConfigurationManager.AppSettings["Test_Facebook_AppId"],
                    AppSecret = ConfigurationManager.AppSettings["Test_Facebook_AppSecret"],
                    //SendAppSecretProof = true,
                    Provider = new FacebookAuthenticationProvider
                    {
                        OnAuthenticated = (context) =>
                        {
                            context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                            return Task.FromResult(0);
                        }
                    }
                };
