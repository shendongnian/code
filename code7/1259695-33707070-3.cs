    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private int percent = 0;
        public int Percent
        {
            get { return percent; }
            set { percent = value; RaiseProperty(nameof(Percent)); }
        }
        private DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.25) };
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            timer.Tick += (s, e) => { Percent++; if (Percent > 99) Percent = 0; };
            timer.Start();
        }
    }
