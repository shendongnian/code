        public ListCollectionView SceneCollectionView { get; set; }
        public List<string> AllLocations { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var scenes = new List<Scene>();
            scenes.Add(new Scene { Location = "location1"});
            scenes.Add(new Scene { Location = "location2"});
            scenes.Add(new Scene { Location = "location3" });
            SceneCollectionView = new ListCollectionView(scenes);
            AllLocations = new List<string> { "location1", "location2", "location3" };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SceneCollectionView.MoveCurrentToNext();
        }
