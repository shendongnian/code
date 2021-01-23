        var searchListRequest = service.Search.List("snippet");
        searchListRequest.Q = "Google"; // Replace with your search term.
        searchListRequest.MaxResults = 50;
        // Call the search.list method to retrieve results matching the specified query term.
        var searchListResponse = searchListRequest.Execute();
        List<string> videos = new List<string>();
        List<string> channels = new List<string>();
        List<string> playlists = new List<string>();
        // Add each result to the appropriate list, and then display the lists of
        // matching videos, channels, and playlists.
        foreach (var searchResult in searchListResponse.Items)
        {
            switch (searchResult.Id.Kind)
            {
                case "youtube#video":
                    videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                    break;
                case "youtube#channel":
                    channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                    break;
                case "youtube#playlist":
                    playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                    break;
            }
        }
    }
