    public void GetTwitterFeeds(dynamic settings, bool ishashtag, DateTime startDate, DateTime endDate)
            {
                string screenname = settings.socialFetchTerm.ToString();
                var auth = new SingleUserAuthorizer
                {
                    Credentials = new InMemoryCredentials
                    {
                        ConsumerKey = AppSettings.ConsumerKey,
                        ConsumerSecret = AppSettings.ConsumerSecret,
                        OAuthToken = AppSettings.AccessToken,
                        AccessToken = AppSettings.AccessTokenSecret
                    }
                };
                var twitterCtx = new TwitterContext(auth);
    
                var ownTweets = new List<Status>();
                ulong sinceId = 0;
                ulong maxID = 0;
                int lastStatusCount = 0;
                bool flag = true;
                var statusResponse = new List<Status>();
                if (!ishashtag)
                {
    
                    statusResponse = (from tweet in twitterCtx.Status
                                      where tweet.Type == StatusType.User
                                            && tweet.ScreenName == screenname
                                            && tweet.Count == 200
                                            && (tweet.CreatedAt >= startDate && tweet.CreatedAt <= endDate)
                                      select tweet).ToList();
                }
                else
                {
                    statusResponse = (from search in twitterCtx.Search
                                      where search.Type == SearchType.Search &&
                                            search.Query == screenname
                                            && search.Count == 200
                                      from Status status in search.Statuses
                                      where (status.CreatedAt >= startDate && status.CreatedAt <= endDate)
                                      select status
                        ).ToList();
                }
                if (statusResponse.Count > 0)
                {
                    maxID = ulong.Parse(statusResponse.First().StatusID);
                    ownTweets.AddRange(statusResponse);
                }
                do
                {
                    int rateLimitStatus = twitterCtx.RateLimitRemaining;
    
                    if (rateLimitStatus != 0)
                    {
                        if (ishashtag)
                        {
                            
                                statusResponse = (from search in twitterCtx.Search
                                                  where search.Type == SearchType.Search &&
                                                        search.Query == screenname
                                                        && search.Count ==200
                                                  from Status status in search.Statuses
                                                  where
                                                      (status.CreatedAt >= startDate && status.CreatedAt <= endDate) &&
                                                      status.SinceID == sinceId && status.MaxID == maxID
                                                  select status
                                    ).ToList();
    
    
    
                                lastStatusCount = statusResponse.Count;
    
                                if (lastStatusCount != 0)
                                {
                                    maxID = ulong.Parse(statusResponse.Last().StatusID) - 1;
    
                                    ownTweets.AddRange(statusResponse);
                                }
                                else
                                {
                                    flag = false;
                                }
                        }
    
                        else
                        {
    
                                statusResponse = (from tweet in twitterCtx.Status
                                                  where tweet.Type == StatusType.User
                                                        && tweet.ScreenName == screenname
                                                        && tweet.SinceID == sinceId && tweet.MaxID == maxID
                                                        && tweet.Count == 200 
                                                        && (tweet.CreatedAt >= startDate && tweet.CreatedAt <= endDate)
                                                  select tweet).ToList();
    
    
                                lastStatusCount = statusResponse.Count;
    
                                if (lastStatusCount != 0)
                                {
                                    maxID = ulong.Parse(statusResponse.Last().StatusID) - 1;
    
                                    ownTweets.AddRange(statusResponse);
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                    }
                    else
                    {
                        flag = false;
                    }
    
                } while (flag);
    
                foreach (var tweetStatus in ownTweets)
                {
                    if (tweetStatus != null)
                    {
                        var socialSiteData = new SocialSitesData
                        {
                            //  SocialType = SocialType.Twitter,
                            
                            SocialType = settings.socialType,
                            SocialSubType = settings.socialSubType,
                            SocialFetchTerm = settings.socialFetchTerm,
                            PostId = tweetStatus.StatusID,
                            Post = tweetStatus.Text,
                            PostUrl = "https://twitter.com/" + tweetStatus.ScreenName + "/status/" + tweetStatus.StatusID,
                            ImageSource =
                                tweetStatus.Entities.MediaEntities.Count > 0
                                    ? tweetStatus.Entities.MediaEntities[0].MediaUrl
                                    : "",
                            VideoSource =
                                tweetStatus.Entities.UrlEntities.Count > 0
                                    ? tweetStatus.Entities.UrlEntities[0].ExpandedUrl
                                    : "",
                            PostTime = tweetStatus.CreatedAt,
                        };
                        if (!_socialHubCrudDal.IsSocialSiteDataExists(tweetStatus.StatusID))
                            _socialHubCrudDal.AddSocialSiteData(socialSiteData);
                    }
                }
            }
