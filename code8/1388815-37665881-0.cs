    // Get an access token for the given context and resourceId. An attempt is first made to 
    // acquire the token silently. If that fails, then we try to acquire the token by prompting the user.
    public static async Task<string> GetTokenHelperAsync(string resource)
    {        
    string token = "";
                aadAccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", authority);
    
                // Get Microsoft Web Account Manager Provider
                var provider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", authority);
    
                // Request result token to Web Account Manager
                WebTokenRequest webTokenRequest = new WebTokenRequest(provider, "", clientId);
                webTokenRequest.Properties.Add("resource", resource);
                WebTokenRequestResult webTokenResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest);
    
                // Show access token
                if (webTokenResult.ResponseStatus == WebTokenRequestStatus.Success)
                {
                    WebTokenResponse webTokenResponse = webTokenResult.ResponseData[0];
                    userAccount = webTokenResponse.WebAccount;
                    token = webTokenResponse.Token;
                }
    
                if (userAccount != null)
                {
                    // Save user ID in local storage.
                    _settings.Values["userID"] = userAccount.Id;
                    _settings.Values["userEmail"] = userAccount.UserName;
                    _settings.Values["userName"] = userAccount.Properties["DisplayName"];
                }
                else
                {
                    SignOut();
                    return null;
                }
    
                return token;
    
            }`
