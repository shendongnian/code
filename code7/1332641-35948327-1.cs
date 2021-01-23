    var _credential = await 
    GoogleWebAuthorizationBroker.AuthorizeAsync(UriFromRelativePath(this, "/API/client_secret.json"), new[] { YouTubeService.Scope.Youtube, YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None);
    public static Uri UriFromRelativePath(FrameworkElement parent, string path)
        {
            try
            {
                var uri = new Uri(parent.BaseUri, path);
                
                return uri;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
