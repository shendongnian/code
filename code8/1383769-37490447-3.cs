        public Page() {
        
            InitializeComponent();
            Loaded += Page_Loaded;
        
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            startAni("spin", image1.Name);
            startAni("spin", image2.Name);
        }
