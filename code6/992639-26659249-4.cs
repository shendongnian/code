    private async Task<Models.YouTubeViewModel> Search(string searchTerm)
    {
        var user = (ClaimsPrincipal)Thread.CurrentPrincipal;
        var at = user.Claims.FirstOrDefault(x => x.Type == Constants.GoogleAccessToken);
        var rt = user.Claims.FirstOrDefault(x => x.Type == Constants.GoogleRefreshToken);
        if (at == null || rt == null)
            throw new HttpUnhandledException("Access / Refresh Token missing");
        TokenResponse token = new TokenResponse
        {
            AccessToken = at.Value,
            RefreshToken = rt.Value
        };
        var cred = new UserCredential(new GoogleAuthorizationCodeFlow(
                    new GoogleAuthorizationCodeFlow.Initializer()
                    {
                        ClientSecrets = new ClientSecrets()
                                        {
                                            ClientId = Constants.GoogleClientId,
                                            ClientSecret = Constants.GoogleClientSecret
                                        }
                    }
                ),
                User.Identity.GetApplicationUser().UserName,
                token
            );
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApplicationName = this.GetType().ToString(),
            HttpClientInitializer = cred,
        });
        var searchListRequest = youtubeService.Search.List("snippet");
        searchListRequest.Q = searchTerm;
        searchListRequest.MaxResults = 50;
        // Call the search.list method to retrieve results matching the specified query term.
        var searchListResponse = await searchListRequest.ExecuteAsync();
        Models.YouTubeViewModel vm = new Models.YouTubeViewModel(searchTerm);
        foreach (var searchResult in searchListResponse.Items)
        {
            switch (searchResult.Id.Kind)
            {
                case "youtube#video":
                    vm.Videos.Add(new Models.Result(searchResult.Snippet.Title, searchResult.Id.VideoId));
                    break;
                case "youtube#channel":
                    vm.Channels.Add(new Models.Result(searchResult.Snippet.Title, searchResult.Id.ChannelId));
                    break;
                case "youtube#playlist":
                    vm.Playlists.Add(new Models.Result(searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                    break;
            }
        }
        return vm;
    }
