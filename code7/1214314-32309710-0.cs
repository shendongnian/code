     public ObservableCollection<Bar> Source { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Bar bar = new Bar("bar1");
            bar.Children.Add(new Bar("bar1.1"));
            bar.Children[0].Children.Add(new Bar("bar1.1.1"));
            bar.Children.Add(new Bar("bar2"));
            Source = new ObservableCollection<Bar>() { bar };
            this.DataContext = this;
        }
