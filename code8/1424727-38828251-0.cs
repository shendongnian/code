        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var user = GetUsersAsync().SingleOrDefault(x => x.Username == context.UserName && x.Password == context.Password);
            if (user != null)
            {
                context.AuthenticateResult = new AuthenticateResult(user.Subject, user.Username);
            }
            return Task.FromResult(0);
        }
        private static List<CustomUser> GetUsersAsync()
        {
            var response =  GetTokenAsync();
            var result = CallUserApi(response.Result.AccessToken).Result;
            var users = JsonConvert.DeserializeObject<List<CustomUser>>(result);
            return users;
        }
        private static Task<string> CallUserApi(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var json = client.GetStringAsync($"https://your.apiAdress.here/");
            return json;
        }
        private static Task<IdentityModel.Client.TokenResponse> GetTokenAsync()
        {
            var client = new TokenClient(
                "https://identityserver.adress.here/identity/connect/token",
                "clientId",
                "secret");
            return client.RequestClientCredentialsAsync("apiScope");
        }
        
