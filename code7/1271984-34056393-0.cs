    var nextPageToken = "";
            while (nextPageToken != null)
            {
              var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
              playlistItemsListRequest.PlaylistId = uploadsListId;
              playlistItemsListRequest.MaxResults = 50;
              playlistItemsListRequest.PageToken = nextPageToken;
    
              // Retrieve the list of videos uploaded to the authenticated user's channel.
              var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
    
              foreach (var playlistItem in playlistItemsListResponse.Items)
              {
                // Print information about each video.
                Console.WriteLine("{0} ({1})", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
              }
    
              nextPageToken = playlistItemsListResponse.NextPageToken;
            }
