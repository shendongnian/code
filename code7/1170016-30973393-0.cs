        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int t = 240000; // 4 minutes = 240,000 milliseconds
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //1 frame in 42 milliseconds = 24 frame per seconds
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 42);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Go back 1 frame every 42 milliseconds (or 24 fps)
            t = t - 42;
            mePlayer.Position = TimeSpan.FromMilliseconds(t);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Pause and go to 4th minute of the video then start playing backward
            mePlayer.Pause();                               
            mePlayer.Position = TimeSpan.FromMinutes(4);
            dispatcherTimer.Start();
        }
