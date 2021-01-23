        public async Task<ActionResult> AuthCallbackAsync()
        {
           NameValueCollection parms = Request.QueryString;
           var authCode = parms["code"]
           //Get "config" - you can store this in session or in a cache.
           var config = new BoxConfig(clientId, clientSecret, redirectUri);
           var client = new BoxClient(config);
            
           await client.Auth.AuthenticateAsync(authCode);
           //Now you will get the accesstoken and refresh token 
           var accessToken = client.Auth.Session.AccessToken;
           var refreshToken = client.Auth.Session.RefreshToken;
           //Ready to consume the API
           var user = await client.UsersManager.GetCurrentUserInformationAsync();
             
            -------More Api Calls--- 
        }
