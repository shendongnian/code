    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Dispatcher.InvokeAsync(() =>
                        {
                            customCombobox.CurrentValue = ClassType.Type3;//Updating the UserControl DP
                        });
                    Thread.Sleep(2000);
                    Dispatcher.InvokeAsync(() =>
                    {
                        this.CurrentValue = ClassType.Type1;//Updating my local Property
                    });
                });
        }
        private ClassType _currentValue;
        public ClassType CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                Debug.WriteLine("Value Changed to " + value.ToString());
                RaisePropertyChanged("CurrentValue");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propName)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(propName));
        }
    }
