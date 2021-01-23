     /// <summary>
            /// using Public APi key
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">A string used to identify a user.</param>
            /// <returns></returns>
            public static YouTubeService AuthenticateOauth(string apiKey)
            {
                try
                {
                    YouTubeService service = new YouTubeService(new YouTubeService.Initializer()
                    {
                        ApiKey = apiKey,
                        ApplicationName = "YouTube Data API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    return null;
                }
    
            }
