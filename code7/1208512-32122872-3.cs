            public MainWindow()
            {
                InitializeComponent();
              
                List<string> l = new List<string>();
                l.Add("string path 1");
                l.Add("string path 2");
                l.Add("string path 3");
                l.Add("string path 4");
                lb.ItemsSource = l;
      
            }
