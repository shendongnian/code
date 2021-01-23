    public partial class Window3 : Window, INotifyPropertyChanged
    {
        public Window3()
        {
            InitializeComponent();
            this.DataContext = this;
            //PermissionsFlag = true;
            CCTVPath = "youtube.com";
        }
        private bool _permissionsFlag = false;
        private string _cctvPath;
        public bool PermissionsFlag
        {
            get { return _permissionsFlag; }
            set
            {
                _permissionsFlag = value;
                OnPropertyChanged("PermissionsFlag");
            }
        }
        public string CCTVPath
        {
            get { return _cctvPath; }
            set
            {
                _cctvPath = value;
                OnPropertyChanged("CCTVPath");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
