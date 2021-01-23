    var service = new TwitterService(consumerKey, consumerSecret);
    service.AuthenticateWith(accessToken, accessTokenSecret);
    SearchOptions options = new SearchOptions { Q = "#Bahrain", Count = 100, Resulttype = TwitterSearchResultType.Popular};
    TwitterSearchResult searchedTweets = service.Search(options);
    foreach(var tweet in searchedTweets.Statuses)
    {
         MessageBox.Show( tweet.Author.ScreenName);
    }
