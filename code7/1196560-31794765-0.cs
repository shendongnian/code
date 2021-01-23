            // 20150802
        public async Task<List<YouTubeInfo>> PlaylistVideosInfo(String PlaylistID)
        {
            var YoutubeService = YouTubeService();
            //
            List<YouTubeInfo> VideoInfos = new List<YouTubeInfo>();
            //
            var NextPageToken = "";
            while (NextPageToken != null)
            {
                // 
                var SearchListRequest = YoutubeService.PlaylistItems.List("snippet");
                SearchListRequest.PlaylistId = PlaylistID;
                SearchListRequest.MaxResults = 50;
                SearchListRequest.PageToken = NextPageToken;
                // Call the search.list method to retrieve results matching the specified query term.
                var SearchListResponse = await SearchListRequest.ExecuteAsync();
                // Collect Video IDs from this page
                var VideoIDsBatch = new List<string>(); // batch Video detail search by 50 max
                foreach (var searchResult in SearchListResponse.Items)
                {
                    VideoIDsBatch.Add(searchResult.Snippet.ResourceId.VideoId);                    
                }
                // Make API call for this batch  - expect a single page :(
                var VideoListRequest = YoutubeService.Videos.List("snippet,contentDetails");
                VideoListRequest.Id = String.Join(",", VideoIDsBatch); 
                VideoListRequest.MaxResults = 50;
                var VideoListResponse = await VideoListRequest.ExecuteAsync();
                // Collect each Video details
                foreach (var VideoResult in VideoListResponse.Items)
                {
                    YouTubeInfoAdd(VideoInfos, VideoResult);
                }
                // request next page
                NextPageToken = SearchListResponse.NextPageToken;
            }
            // Return All Videos' detail
            return VideoInfos;
        }
