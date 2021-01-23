    var Tweets = new List<string>();
    Tweets.Add("RT @randomuser_: what you saying");
    Tweets.Add("@randomusertwo hello this is a tweet");
    var usernames = new List<string>();
    foreach (var men in Tweets)
    {
        var regex = new Regex(@"@[\w\d_]{1,15}");
        foreach (Match match in regex.Matches(men))
        {
            usernames.Add(match.Value);
        }
    }
