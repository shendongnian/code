    public async void RetrieveUploadsList()
    {
        UserCredentials();
        var youtubeService = UserYoutubeService(); // <--- Change is here
    
        var channelsListRequest = youtubeService.Channels.List("contentDetails");
        ...
