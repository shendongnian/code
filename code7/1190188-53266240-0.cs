    Public Sub ConfigureAuth(app As IAppBuilder)
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)
       app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType)
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)
    
        Dim facebookOptions = New FacebookAuthenticationOptions With {
            .AppId = ConfigurationManager.AppSettings("FacebookClientID"),
            .AppSecret = ConfigurationManager.AppSettings("FacebookClientSecret"),
            .Provider = New FacebookAuthenticationProvider With {
                .OnAuthenticated = Function(context)
                                       context.Identity.AddClaim(New Claim("Provider", "Facebook"))
                                       context.Identity.AddClaim(New Claim("provider:name", context.Identity.FindFirstValue(ClaimTypes.Name)))
                                       context.Identity.AddClaim(New Claim("provider:accesstoken", context.AccessToken, ClaimValueTypes.String, "Facebook"))
                                       context.Identity.AddClaim(New Claim("provider:picture", String.Format("//graph.facebook.com/{0}/picture?type=square", context.User.Value(Of String)("id"))))
                                       Dim email = context.Identity.FindFirstValue(ClaimTypes.Email)
                                       If email IsNot Nothing Then
                                           context.Identity.AddClaim(New Claim("provider:email", email))
                                       Else
                                           Dim fb = New Facebook.FacebookClient(context.AccessToken)
                                           Dim myInfo = fb.Get("/me?fields=email")
                                           email = myInfo("email")
                                           If email IsNot Nothing Then
                                               context.Identity.AddClaim(New Claim("provider:email", email))
                                           Else
                                               Throw New ArgumentNullException("myInfo.Email")
                                           End If
                                       End If
    
                                       Return Task.FromResult(0)
                                   End Function}}
        facebookOptions.Scope.Add("email")
        app.UseFacebookAuthentication(facebookOptions)
    
        app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
           .ClientId = ConfigurationManager.AppSettings("GoogleClientID"),
           .ClientSecret = ConfigurationManager.AppSettings("GoogleClientSecret"),
           .Provider = New GoogleOAuth2AuthenticationProvider With {.OnAuthenticated = Function(context)
                                                                                           context.Identity.AddClaim(New Claim("Provider", "Google"))
                                                                                           context.Identity.AddClaim(New Claim("provider:name", context.Identity.FindFirstValue(ClaimTypes.Name)))
                                                                                           context.Identity.AddClaim(New Claim("provider:email", context.Identity.FindFirstValue(ClaimTypes.Email)))
                                                                                           context.Identity.AddClaim(New Claim("provider:accesstoken", context.AccessToken, ClaimValueTypes.String, "Google"))
                                                                                           context.Identity.AddClaim(New Claim("provider:picture", context.User.SelectToken("image")?.Value(Of String)("url")))
    
                                                                                           Return Task.FromResult(0)
                                                                                       End Function}})
    
        app.UseLinkedInAuthentication(New LinkedInAuthenticationOptions With {
            .ClientId = ConfigurationManager.AppSettings("LinkedInClientID"),
            .ClientSecret = ConfigurationManager.AppSettings("LinkedInClientSecret"),
            .Provider = New LinkedInAuthenticationProvider With {.OnAuthenticated = Function(context)
                                                                                        context.Identity.AddClaim(New Claim("Provider", "LinkedIn"))
                                                                                        context.Identity.AddClaim(New Claim("provider:name", context.Name))
                                                                                        context.Identity.AddClaim(New Claim("provider:email", context.Email))
                                                                                        context.Identity.AddClaim(New Claim("provider:accesstoken", context.AccessToken, ClaimValueTypes.String, "LinkedIn"))
                                                                                        context.Identity.AddClaim(New Claim("provider:picture", context.User.SelectToken("pictureUrl").ToString))
    
                                                                                        Return Task.FromResult(0)
                                                                                    End Function}})
    
        Dim oktaOptions = New OpenIdConnect.OpenIdConnectAuthenticationOptions With {
            .AuthenticationType = "okta",
            .SignInAsAuthenticationType = "Cookies",
            .Authority = ConfigurationManager.AppSettings("okta:Authority"),
            .ResponseType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.CodeIdToken,
            .ClientId = ConfigurationManager.AppSettings("okta:ClientId"),
            .ClientSecret = ConfigurationManager.AppSettings("okta:ClientSecret"),
            .RedirectUri = ConfigurationManager.AppSettings("okta:RedirectUri"),
            .TokenValidationParameters = New Microsoft.IdentityModel.Tokens.TokenValidationParameters With {.ValidateIssuer = True},
            .Scope = "openid profile email"
        }
        app.UseOpenIdConnectAuthentication(oktaOptions)
    
    
        Dim auth0Options = New OpenIdConnect.OpenIdConnectAuthenticationOptions With {
            .AuthenticationType = "auth0",
            .SignInAsAuthenticationType = "Cookies",
            .Authority = ConfigurationManager.AppSettings("auth0:Authority"),
            .ResponseType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.CodeIdToken,
            .ClientId = ConfigurationManager.AppSettings("auth0:ClientId"),
            .ClientSecret = ConfigurationManager.AppSettings("auth0:ClientSecret"),
            .RedirectUri = ConfigurationManager.AppSettings("auth0:RedirectUri"),
            .TokenValidationParameters = New Microsoft.IdentityModel.Tokens.TokenValidationParameters With {.ValidateIssuer = True},
            .Scope = "openid profile email"
        }
        app.UseOpenIdConnectAuthentication(auth0Options)
    
        app.MapSignalR
    
        GlobalHost.DependencyResolver.Register(GetType(IUserIdProvider), Function() New MySignalRIdProvider())
    End Sub
