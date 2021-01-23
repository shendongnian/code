        public void GetTwitterFeeds(string screenName, DateTime startDate, DateTime endDate)
        {
            var twitterCtx = new TwitterContext(authorizer);
            var ownTweets = new List<Status>();
            ulong maxID = 0;
            int lastStatusCount = 0;
            bool flag = true;
            var statusResponse = new List<Status>();
            
            statusResponse = (from tweet in twitterCtx.Status
                                where tweet.Type == StatusType.User
                                    && tweet.ScreenName == screenName
                                    && tweet.Count == 200
                                    && (tweet.CreatedAt >= startDate && tweet.CreatedAt <= endDate)
                                select tweet).ToList();
            if (statusResponse.Count > 0)
            {
                maxID = ulong.Parse(statusResponse.Last().StatusID.ToString());
                ownTweets.AddRange(statusResponse);
            }
            if (ownTweets.Count == 200)
            {
                do
                {
                    int rateLimitStatus = twitterCtx.RateLimitRemaining;
                    if (rateLimitStatus != 0)
                    {
                        statusResponse = (from tweet in twitterCtx.Status
                                          where tweet.Type == StatusType.User
                                              && tweet.ScreenName == screenName
                                              && tweet.MaxID == maxID
                                              && tweet.Count == 200
                                              && (tweet.CreatedAt >= startDate && tweet.CreatedAt <= endDate)
                                          select tweet).ToList();
                        lastStatusCount = statusResponse.Count;
                        if (lastStatusCount != 0)
                        {
                            maxID = ulong.Parse(statusResponse.Last().StatusID.ToString()) - 1;
                            ownTweets.AddRange(statusResponse);
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag);
            }
            if (statusResponse.Count > 0)
            {
                foreach (Status tweet in ownTweets)
                {
                    listTweets.Items.Add(tweet.Text);
                }
                lb_tUser.Text = "@" + screenName;
                lb_tweeted.Text = statusResponse.Count.ToString();
            }
        }
