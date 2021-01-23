    private static async Task CheckAndPossiblyRefreshToken(ClaimsIdentity id)
        {
            var clientName = "Myhybridclient";
            // check if the access token hasn't expired.
            if (DateTime.Now.ToLocalTime() >=
                 (DateTime.Parse(id.FindFirst("expires_at").Value)))
            {
                // expired.  Get a new one.
                var tokenEndpointClient = new OAuth2Client(
                    new Uri(Constants.TokenEndpoint),
                    clientName,
                    "secret");
                var tokenEndpointResponse =
                    await tokenEndpointClient
                    .RequestRefreshTokenAsync(id.FindFirst("refresh_token").Value);
                if (!tokenEndpointResponse.IsError)
                {
                    // replace the claims with the new values - this means creating a 
                    // new identity!                              
                    var result = from claim in id.Claims
                                 where claim.Type != "access_token" && claim.Type != "refresh_token" &&
                                       claim.Type != "expires_at"
                                 select claim;
                    var claims = result.ToList();
                    claims.Add(new Claim("access_token", tokenEndpointResponse.AccessToken));
                    claims.Add(new Claim("expires_at",
                                 DateTime.Now.AddSeconds(tokenEndpointResponse.ExpiresIn)
                                 .ToLocalTime().ToString()));
                    claims.Add(new Claim("refresh_token", tokenEndpointResponse.RefreshToken));
                    var newIdentity = new ClaimsIdentity(claims, "Cookies");
                    var wrapper = new HttpRequestWrapper(HttpContext.Current.Request);
                    wrapper.GetOwinContext().Authentication.SignIn(newIdentity);
                }
                else
                {
                    // log, ...
                    throw new Exception("An error has occurred");
                }
            }
        } 
 
