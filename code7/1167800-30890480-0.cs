        foreach (var playlist in playlistResponse.Items)
        {
            var playlistItemRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemRequest.PlaylistId = playlist.Id;
            playlistItemRequest.MaxResults = 50;
            var videos = await playlistItemRequest.ExecuteAsync();
            foreach (var video in videos.Items)
            {
                Console.WriteLine(video.Snippet.Title);
            }
        }
