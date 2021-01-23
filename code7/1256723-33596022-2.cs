    using (var streamReader = System.IO.File.OpenText("D:\\file.txt"))
    {
        using (StreamWriter writer = new StreamWriter("D:\\ft1.txt"))
        {
            DateTime? startTime = null;
            while(streamReader.Peek() >= 0)
            {
                var line = streamReader.ReadLine();
                var tweet = JsonConvert.DeserializeObject<TweetModel>(line);
                var createdAt = tweet.CreatedAt;
                // set the start time when it has not been set yet
                startTime = startTime ?? createdAt;
                // leave the while loop when createdAt is later than startTime plus 30 seconds
                if (createdAt > (startTime.Value + TimeSpan.FromSeconds(30)))
                {
                    break;
                }
                // do something useful with the tweet
            }
        }
    }
