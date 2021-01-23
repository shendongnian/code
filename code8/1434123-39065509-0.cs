    var auth = new ApplicationOnlyAuthorizer
    {
        Credentials = new InMemoryCredentials
        {
            ConsumerKey = [ConsumerKey],
            ConsumerSecret = [ConsumerSecret]
        }
    };
    
    auth.Authorize();
    
    var _twitterContext = new TwitterContext(auth);
    
    var srch =
        (from search in _twitterContext.Search
         where search.Type == SearchType.Search &&
               search.Query == "twitter" &&
               search.Count == 7 &&
               search.GeoCode == "51.507351,-0.127758,1km"
         select search)
        .SingleOrDefault();
    
    Console.WriteLine("\nQuery: {0}\n", srch.SearchMetaData.Query);
    srch.Statuses.ForEach(entry =>
        Console.WriteLine(
            "ID: {0, -15}, Source: {1}\nContent: {2}\n",
            entry.StatusID, entry.Source, entry.Text));
    
    Console.ReadLine();
