    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CancellationTokenSource _tokenSource;
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
        private async void SetEndPosition()
        {
            _tokenSource?.Cancel();
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            await Task.Run(() =>
            {
                if (token.IsCancellationRequested)
                    return;
                while (!token.IsCancellationRequested)
                {
                    Dispatcher.Invoke(() =>
                    {
                        double position = media.Position.TotalSeconds;
                        if (position >= Stop)
                            SetStartPosition();
                    });
                    Thread.Sleep(100);
                }
            }, token);
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
