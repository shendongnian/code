    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Interval = _baseInterval;
            _stopWatch.Restart();
        }
        private TimeSpan _baseInterval = TimeSpan.FromSeconds(5);
        private DispatcherTimer _timer;
        private Stopwatch _stopWatch = new Stopwatch();
        // Call from appropriate location to toggle timer, e.g. in a button's
        // Click event handler.
        private void ToggleTimer()
        {
            if (_timer.IsEnabled)
            {
                _timer.IsEnabled = false;
                _stopWatch.Stop();
                button1.Content = "Start";
            }
            else
            {
                _timer.Interval = _baseInterval - _stopWatch.Elapsed;
                _stopWatch.Restart();
                _timer.IsEnabled = true;
            }
        }
    }
