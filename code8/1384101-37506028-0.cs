        public string PublishTweet(string text)
        {
            var appCredentials = new TwitterCredentials(_apiKey,_apiSecret, _accessToken, _accessTokenSecret);
            Tweetinvi.Auth.SetCredentials(appCredentials);
            text = "my tweet";
            var publishedTweet = Tweetinvi.Tweet.PublishTweet(text);
            var tweetId = publishedTweet.Id.ToString();
            return tweetId;
        }
