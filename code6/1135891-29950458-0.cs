        private static ITweet[] GetUserTimelineTweets(string userName, int maxNumberOfTweets)
        {
            var tweets = new List<ITweet>();
            var receivedTweets = Timeline.GetUserTimeline(userName, 200).ToArray();
            tweets.AddRange(receivedTweets);
            while (tweets.Count < maxNumberOfTweets && receivedTweets.Length == 200)
            {
                var oldestTweet = tweets.Min(x => x.Id);
                var userTimelineParameter = Timeline.CreateUserTimelineRequestParameter(userName);
                userTimelineParameter.MaxId = oldestTweet;
                userTimelineParameter.MaximumNumberOfTweetsToRetrieve = 200;
                receivedTweets = Timeline.GetUserTimeline(userTimelineParameter).ToArray();
                tweets.AddRange(receivedTweets);
            }
            return tweets.Distinct().ToArray();
        }
