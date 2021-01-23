    public MainWindow()
        {
            InitializeComponent();
            
            // you will get entries using your code, I hard-coded anonymous objects
            Dictionary<string, object> entries = new Dictionary<string, object>();
            entries.Add("People", new [] { new { Name = "name1", Age = 24 } });
            entries.Add("Places", new[] { new { City = "agra", Country = "India" } });
            this.DataContext = entries;
        }
