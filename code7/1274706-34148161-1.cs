    using Google.Apis.Services;
    using Google.Apis.YouTube.v3;
    
    public ActionResult GetVideo(YouTubeData objYouTubeData)
    {
        try
        {
            var yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "Your API Key" });
            var channelsListRequest = yt.Channels.List("contentDetails");
            channelsListRequest.ForUsername = "kkrofficial";
            var channelsListResponse = channelsListRequest.Execute();
            foreach (var channel in channelsListResponse.Items)
            {
                // of videos uploaded to the authenticated user's channel.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = yt.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;
                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = playlistItemsListRequest.Execute();
                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        // Print information about each video.
                        //Console.WriteLine("Video Title= {0}, Video ID ={1}", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
                        var qry = (from s in ObjEdbContext.ObjTubeDatas where s.Title == playlistItem.Snippet.Title select s).FirstOrDefault();
                        if (qry == null)
                        {
                            objYouTubeData.VideoId = "https://www.youtube.com/embed/" + playlistItem.Snippet.ResourceId.VideoId;
                            objYouTubeData.Title = playlistItem.Snippet.Title;
                            objYouTubeData.Descriptions = playlistItem.Snippet.Description;
                            objYouTubeData.ImageUrl = playlistItem.Snippet.Thumbnails.High.Url;
                            objYouTubeData.IsValid = true;
                            ObjEdbContext.ObjTubeDatas.Add(objYouTubeData);
                            ObjEdbContext.SaveChanges();
                            ModelState.Clear();
                        }
                    }
                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
        }
        catch (Exception e)
        {
            ViewBag.ErrorMessage = "Some exception occured" + e;
            return RedirectToAction("GetYouTube");
        }
        return RedirectToAction("GetYouTube");
    }
