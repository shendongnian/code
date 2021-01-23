        DispatcherTimer timer1 = new DispatcherTimer();
        double num = 0;
        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = new TimeSpan(0,0,0,0,250);
            timer1.Tick += timer1_Tick;
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Scroll_Content.ScrollToHorizontalOffset(num);
                num++;
            }
            catch { }
        }
        void Start_Timer_Click(object sender, RoutedEventArgs e)
        {
            if (timer1.IsEnabled == false) 
            {
                num = 0;
                timer1.Start();
            }
            else
                timer1.Stop();
                
        }
