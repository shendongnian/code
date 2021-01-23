    public sealed partial class ClockPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public ClockPage()
        {
            InitializeComponent();
            DataContext = this;
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
    }
