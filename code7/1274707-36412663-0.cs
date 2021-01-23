            public Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        {
            return Task.Run(() =>
            {
                List<SearchResult> res = new List<SearchResult>();
                string nextpagetoken = " ";
                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Search.List("snippet");
                    searchListRequest.MaxResults = 50;
                    searchListRequest.ChannelId = ytChannelId;
                    searchListRequest.PageToken = nextpagetoken;
                    searchListRequest.Type      = "video";
                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();
                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);
                    nextpagetoken = searchListResponse.NextPageToken;
                }
                return res;
            });
        }
