        public Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        {
            return Task.Run(() =>
            {
                List<SearchResult> res = new List<SearchResult>();
    var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaXyBa0HT1K81LpprSpWvxa70thZ6Bx4KD666",
                ApplicationName = "Videopedia"//this.GetType().ToString()
            });
                string nextpagetoken = " ";
                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Search.List("snippet");
                    searchListRequest.MaxResults = 50;
                    searchListRequest.ChannelId = ytChannelId;
                    searchListRequest.PageToken = nextpagetoken;
                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();
                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);
                    nextpagetoken = searchListResponse.NextPageToken;
                }
                return res;
            });
        } 
