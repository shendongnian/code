    public class TweetViewModel
    {
        private readonly ITweet _tweet;
        public TweetViewModel(ITweet tweet)
        {
            _tweet = tweet;
        }
        public string Text
        {
            get { return _tweet.Text; }
        }
        public string CreatedBy
        {
            get { return _tweet.CreatedBy.Name; }
        }
        // ...
    }
