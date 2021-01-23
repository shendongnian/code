    static async Task<List<Status>> ListTweetsOnUserTimeline(string screenName)
    {
        var auth = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                AccessTokenSecret = accessTokenSecret
            }
        };
        using (var context = new TwitterContext(auth))
        {
            var tweets = await (from tweet in context.Status
                                where tweet.Type == StatusType.User &&
                                        tweet.Count == 200 &&
                                        tweet.ScreenName == screenName
                                select tweet)
                                .ToListAsync();
            return tweets;
        }
    }
