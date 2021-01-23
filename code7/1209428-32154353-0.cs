        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var scenes = new ObservableCollection<Scene>();
            scenes.Add(new Scene { Location = "location1"});
            scenes.Add(new Scene { Location = "location2"});
            scenes.Add(new Scene { Location = "location3" });
            SceneCollectionView = new ListCollectionView(scenes);
            AllLocations = new List<string> { "location1", "location2", "location3" };
        }
