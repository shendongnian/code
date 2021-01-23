     public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public String Verified { get; set; }
        private String _status = "Verified";
        public String Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status == value)
                {
                    return;
                }
                _status = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Verified = "Verified";
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
