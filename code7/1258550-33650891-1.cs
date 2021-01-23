    public class HeadlineViewModel 
    {
        public HeadlineViewModel()
        {
            // This is here only for simplicity. Put elsewhere
            var config = new TwitterOAuthConfig()
            {
                ConsumerKey = customerKey,
                ConsumerSecret = customerSecret,
                AccessToken = accessToken,
                AccessTokenSecret = accessTokenSecret,
                GeoOnly = false,
                KeywordsToMonitor = keywords,
                UsersToFollow = followers
            };
            var filteredStream = new TwitterClient(config);
            HeadlineCollection = new ObservableCollection<HeadlineDisplayItems>();
            // subscribe to the event handler
            filteredStream.HeadlineReceivedEvent +=
                (sender, arguments) =>     HeadlineCollection.Add(ConvertToViewModel(arguments.Headline));
                    //Console.WriteLine("ID: {0} said {1}",     arguments.Headline.Username, arguments.Headline.HeadlineText);
    
            filteredStream.ExceptionReceived += (sender, exception) =>     Console.WriteLine(exception.HeadlineException.ResponseMessage);
            filteredStream.Start();
        }
    
        private HeadlineDisplayItems ConvertToViewModel(Headline headline)
        {
            // Conversion code here
        }
        public class HeadlineDisplayItems: ObservableItem
        {
            private string _headlineText;
            public string HeadlineIconPath { get; set; }
            public string TimeStamp { get; set; }
            public string Username { get; set; }
            public string Text
            {
                get { return _headlineText; }
                set
                {
                    _headlineText = value;
                    RaisePropertyChangedEvent("HeadlineText");
                }
            }
        }
        public List<string> UrlsParsedFromText { get; set; }
        public ObservableCollection<HeadlineDisplayItems> HeadlineCollection {         get; set; }
    }
