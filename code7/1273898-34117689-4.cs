    private async Task RetrieveUploadsListAsync(IProgress<string> progress)
    {
    	UserCredentials();
    	var youtubeService = new YouTubeService(new BaseClientService.Initializer()
    	{
    		HttpClientInitializer = credential,
    		ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
    	});
    
    	var channelsListRequest = youtubeService.Channels.List("contentDetails");
    	channelsListRequest.Mine = true;
    
    	var channelsListResponse = await channelsListRequest.ExecuteAsync();
    
    	foreach (var channel in channelsListResponse.Items)
    	{
    		var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
    
    		Console.WriteLine("Videos in list {0}", uploadsListId);
    
    		var nextPageToken = "";
    		while (nextPageToken != null)
    		{
    			var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
    			playlistItemsListRequest.PlaylistId = uploadsListId;
    			playlistItemsListRequest.MaxResults = 50;
    			playlistItemsListRequest.PageToken = nextPageToken;
    			var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
    
    			foreach (var playlistItem in playlistItemsListResponse.Items)
    			{
    				videosList.Add(playlistItem.Snippet.Title + "  " + playlistItem.Snippet.ResourceId.VideoId);
    				videosUrl.Add("http://www.youtube.com/v/" + playlistItem.Snippet.ResourceId.VideoId);
    
    				progress.Report(playlistItem.Snippet.Title + "  " + playlistItem.Snippet.PublishedAt);
    			}
    			nextPageToken = playlistItemsListResponse.NextPageToken;
    		}
    	}
    }
