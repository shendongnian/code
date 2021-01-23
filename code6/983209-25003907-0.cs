    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isMainColour;
        public SolidColorBrush CurrentColour { get; set; }
        private DispatcherTimer _timer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_isMainColour)
            {
                CurrentColour = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                CurrentColour = new SolidColorBrush(Colors.Red);
            }
            _isMainColour = !_isMainColour;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentColour"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
