    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private double _value;
        private double _minimum;
        private double _maximum;
        private DoubleCollection _tickCollection;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            TickCollection = new DoubleCollection();
            for (double i = 0.0; i < 5.0; i+=0.5)
            {
                TickCollection.Add(i);
            }
            Minimum = 0.0;
            Maximum = 5.0;
            Value = 2.3;
        }
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        public double Minimum
        {
            get { return _minimum; }
            set { _minimum = value; OnPropertyChanged(); }
        }
        public double Maximum
        {
            get { return _maximum; }
            set { _maximum = value; OnPropertyChanged(); }
        }
        public DoubleCollection TickCollection
        {
            get { return _tickCollection; }
            set
            {
                _tickCollection = value;
                OnPropertyChanged();
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TickCollection = new DoubleCollection();
            for (double i = 5.0; i < 10.0; i += 1.0)
            {
                TickCollection.Add(i);
            }
            Minimum = 5.0;
            Maximum = 10.0;
            Value = 2.3;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
