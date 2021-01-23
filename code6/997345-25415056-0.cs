    public MainWindow()
    {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer 
                {
                    Interval = TimeSpan.FromSeconds(0.5)
                };
            timer.Tick += (o,e) =>
                {
                    DateTime dtCurrentTime = DateTime.Now;
                    label1.Content = dtCurrentTime.ToLongTimeString();
                };
            timer.IsEnabled = true;
    }
