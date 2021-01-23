        MediaPlayer Player => PlaybackService.Instance.Player;
        MediaPlaybackList PlaybackList
        {
            get { return Player.Source as MediaPlaybackList; }
            set { Player.Source = value; }
        }
        public MainPage()
        {
            this.InitializeComponent();
            // Handle page load events
            Loaded += Scenario1_Loaded;
        }
        private void Scenario1_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a new playback list
            if (PlaybackList == null)
                PlaybackList = new MediaPlaybackList();
        }
