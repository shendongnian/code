    var tweet = Tweet.PublishTweet("hello");
    if (tweet != null)
    {
        var userTimeline = Timeline.GetHomeTimeline();
        if (userTimeline != null)
        {
            // foreach ...
        }
    }
