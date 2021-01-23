    // if you don't get this far, the problem is elsewhere
    // if it fails here, the problem is accessing the textbox value
    string status = textBox1.Text;
    // if it fails here, the problem is inside the tweetsharp library,
    // and should be referred to the library authors, but indicating which
    // step fails (constructor vs Status property vs Send method)
    var msg = new SendTweetOptions();
    msg.Status = status;
    servis.SendTweet(msg);
