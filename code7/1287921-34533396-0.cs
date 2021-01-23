            public async void Form1_Load()
            {
                await GetMostRecent100HomeTimeLine();
                lstTweetList.Items.Clear();
                currentTweets.ForEach(tweet =>
                   lstTweetList.Items.Add(tweet.Text));
            }
            private async Task GetMostRecent100HomeTimeLine()
            {
                var twitterContext = new TwitterContext(authorizer);
                var tweets = from tweet in twitterContext.Status
                             where tweet.Type == StatusType.Home &&
                             tweet.Count == 100
                             select tweet;
                currentTweets = await tweets.ToListAsync();
            }
