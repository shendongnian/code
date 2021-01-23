    private YouTubeService UserYoutubeService() // <-- Note return type
    {
        return new YouTubeService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
        });
    }
