         string maxid = "1000000000000"; // dummy value
        int tweetcount = 0;
        if (maxid != null)
        {
            var tweets_search = twitterService.Search(new SearchOptions { Q = keyword, Count = Convert.ToInt32(count) });
            List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
            maxid = resultList.Last().IdStr;
            foreach (var tweet in tweets_search.Statuses)
            {
                try
                {
                    ResultSearch.Add(new KeyValuePair<String, String>(tweet.Id.ToString(), tweet.Text));
                    tweetcount++;
                }
                catch { }
            }
            while (maxid != null && tweetcount < Convert.ToInt32(count))
            {
                maxid = resultList.Last().IdStr;
                tweets_search = twitterService.Search(new SearchOptions { Q = keyword, Count = Convert.ToInt32(count), MaxId = Convert.ToInt64(maxid) });
                resultList = new List<TwitterStatus>(tweets_search.Statuses);
                foreach (var tweet in tweets_search.Statuses)
                {
                    try
                    {
                        ResultSearch.Add(new KeyValuePair<String, String>(tweet.Id.ToString(), tweet.Text));
                        tweetcount++;
                    }
                    catch { }
                }
            }
        }
