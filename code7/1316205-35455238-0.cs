    var us = Stream.CreateUserStream();
    us.TweetCreatedByMe += (sender, args) =>
    {
        // Update your rich textbox by adding the new tweet with tweet.Text
        var tweetPublishedByMe = args.Tweet;
                
        // OR Get your timeline and rewrite the text entirely in your textbox
        var userTimeline = Timeline.GetHomeTimeline();
        if (userTimeline != null)
        {
            // foreach ...
        }
    };
    us.StartStreamAsync();
    
