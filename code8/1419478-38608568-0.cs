    public async Task<DropboxClient> GetClient()
    {
       OAuth2Response authUriComplete = 
               await Dropbox.Api.DropboxOAuth2Helper.ProcessCodeFlowAsync(token, options.ClientId, options.ClientSecret);
       return new DropboxClient(authUriComplete.AccessToken);
    }
