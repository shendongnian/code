    [HttpGet]
    public async Task<ActionResult> oAuth2()
    {
        var authorizationCode = this.Request.QueryString["code"];
        var state = this.Request.QueryString["state"];
        //Defend against CSRF attacks http://www.twobotechnologies.com/blog/2014/02/importance-of-state-in-oauth2.html
        await ValidateStateAsync(state);
        //Exchange Authorization Code for an Access Token by POSTing to the IdP's token endpoint
        string json = null;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(idPServerBaseUri);
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", grantType)
                ,new KeyValuePair<string, string>("code", authorizationCode)
                ,new KeyValuePair<string, string>("redirect_uri", redirectUri)
                ,new KeyValuePair<string, string>("client_id", clientId)              //consider sending via basic authentication header
                ,new KeyValuePair<string, string>("client_secret", clientSecret)
            });
            var httpResponseMessage = client.PostAsync(idPServerTokenUriFragment, content).Result;
            json = httpResponseMessage.Content.ReadAsStringAsync().Result;
        }
        //Extract the Access Token
        dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
        string accessToken = results.access_token;
        //Validate token crypto
        var claims = ValidateToken(accessToken);
        //What is done here depends on your use-case. 
        //If the accessToken is for calling a WebAPI, the next few lines wouldn't be needed. 
            
        //Build claims identity principle
        var id = new ClaimsIdentity(claims, "Cookie");              //"Cookie" matches middleware named in Startup.cs
        //Sign into the middleware so we can navigate around secured parts of this site (e.g. [Authorized] attribute)
        this.Request.GetOwinContext().Authentication.SignIn(id);
        return this.Redirect("/Home"); 
    }
