        List<int> inputs = new List<int>();
        int currentFloor = 1;
        int targetFloor = 1;
        bool IsGoingUp = true;
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0,100);
            timer.Tick += Timer_Tick;
            timer.Start ();
        }
        private void buttonna4_Click(object sender, RoutedEventArgs e)
        {
            inputs.Add(4);
            // Recalculating target floor based on input
            RecalculateTargetFloor();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DrawAnimation(); // Draw small step of elevator to targetFloor
            if (currentFloor == targetFloor)
                RecalculateTargetFloor();
            //waiting for another tick of timer.
        }
