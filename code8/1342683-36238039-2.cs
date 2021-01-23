    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _start;
        private double _stop;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            media.LoadedBehavior = MediaState.Manual;
            Start = 0;
            media.MediaOpened += (sender, args) =>
            {
                Stop = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
                SetEndPosition();
            };
            media.Source = new Uri("video.wmv", UriKind.Relative);
            media.Play();
        }
        private void SetEndPosition()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() =>
                    {
                        double position = media.Position.TotalSeconds;
                        if (position >= Stop)
                            SetStartPosition();
                    });
                    Thread.Sleep(100);
                }
            });
        }
        private void SetStartPosition()
        {
            media.Position = TimeSpan.FromSeconds(Start);
        }
        public double Start
        {
            get { return _start; }
            set { _start = value; OnPropertyChanged(); SetStartPosition(); }
        }
        public double Stop
        {
            get { return _stop; }
            set { _stop = value; OnPropertyChanged(); }
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
