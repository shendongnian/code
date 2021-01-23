                AccessClaims claimsToken = new AccessClaims();
                claimsToken = JsonConvert.DeserializeObject<AccessClaims>(response.Content);
                claimsToken.Cookie = response.Cookies[0].Value;               
                Request.Headers.Add("Authorization", "bearer " + claimsToken.access_token);
                var ctx = Request.GetOwinContext();
                var authenticateResult = await ctx.Authentication.AuthenticateAsync("JWT");
                ctx.Authentication.SignOut("JWT");
                var applicationCookieIdentity = new ClaimsIdentity(authenticateResult.Identity.Claims, DefaultAuthenticationTypes.ApplicationCookie);
                ctx.Authentication.SignIn(applicationCookieIdentity);
		
