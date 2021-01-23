    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _name;
        public string MyName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("MyName");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            MyName = "Eldho";
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
