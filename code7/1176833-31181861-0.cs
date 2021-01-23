    public class MainWindowViewModel : ViewModelBase
    {
        private readonly DispatcherTimer _timer;
        public MainWindowViewModel()
        {
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            _timer.Start();
            _timer.Tick += (o, e) => OnPropertyChanged("CurrentTime");
        }
        public DateTime CurrentTime { get { return DateTime.Now; } }
    }
    <TextBlock Text="{Binding CurrentTime, StringFormat={}{0:HH:mm tt}}" />
