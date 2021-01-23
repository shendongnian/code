     private static void GetAccessTokenNonAsync()
        {
            var userId = ((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirst("UserId").Value;
            var task = System.Threading.Tasks.Task.Run(async () =>
            {
                return await GetAccessToken( userId);
            });
            task.Wait();
            Current.AccessToken = task.Result.AccessToken;
            Current.AccessTokenExpiresOn = task.Result.ExpiresOn.ToString();
        }
        private static async Task<AuthenticationResult> GetAccessToken(string userId)
        {
            return await System.Threading.Tasks.Task.Factory.StartNew<AuthenticationResult>
            (
                () =>
                {
                    string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
                    string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
                    string clientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];
                    string source = ConfigurationManager.AppSettings["ExchangeOnlineId"];
                    var authContext = new AuthenticationContext(aadInstance, false);
                    var credentials = new ClientCredential(clientId, clientSecret);
                    var res =
                        authContext.AcquireTokenSilentAsync(source, credentials,
                            new UserIdentifier(userId, UserIdentifierType.UniqueId)).Result;
                    return res;
                }
            );
        }
