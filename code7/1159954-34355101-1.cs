        private ObservableCollection<Player> players = new ObservableCollection<Player>();
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.players.Add(new Player());
            this.players.Add(new Player());
            this.players.Add(new Player());
            this.players.Add(new Player());
            this.players.Add(new Player());
            this.Players.ItemsSource = players;
        }
